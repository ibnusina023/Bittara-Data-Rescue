using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Animator animator;
    public GameObject deathMenuUI; // Assign di Inspector
    public float deathAnimDelay = 2f; // Delay sesuai durasi animasi mati

    private bool isDead = false;

    void Start()
    {
        deathMenuUI.SetActive(false);
    }

    public void TriggerDeath()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<PlayerMovement>().isDead = true;

        // Hentikan semua gerakan
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;

        // Jalankan animasi
        animator.SetTrigger("DieTrigger");
        AudioManager.Instance.PlaySFX("Explode");

        // Jalankan coroutine untuk tampilkan UI setelah delay
        StartCoroutine(DeathSequence());
    }


    private IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathAnimDelay); // Tunggu animasi selesai
        Time.timeScale = 0f; // Pause physics
        deathMenuUI.SetActive(true); // Tampilkan UI
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene("LevelSelect"); // Ganti sesuai nama scene menu
    }
}
