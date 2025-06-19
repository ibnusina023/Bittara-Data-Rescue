using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TestOverMenu : MonoBehaviour
{
    public static TestOverMenu Instance { get; private set; }

    public GameObject testOverPanel;
    public TextMeshProUGUI liveTimerText;
    public TextMeshProUGUI finalTimerText;

    private bool isTestOver = false;
    private float finalTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        testOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isTestOver && TestTimer.Instance != null)
        {
            // Update live timer saat belum game over
            liveTimerText.text = TestTimer.Instance.GetFormattedTime();
        }
        else if (isTestOver)
        {
            // Saat test over → pastikan live timer tetap tampil sama dengan final timer
            liveTimerText.text = FormatTime(finalTime);
        }
    }

    public void ShowTestOver()
    {
        isTestOver = true;
        testOverPanel.SetActive(true);

        // Ambil waktu final hanya 1x, supaya sync
        finalTime = TestTimer.Instance.GetElapsedTime();

        // Tampilkan waktu ke FinalTimerText dan LiveTimerText
        finalTimerText.text = FormatTime(finalTime);
        liveTimerText.text = FormatTime(finalTime);
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        // Tidak perlu ResetTimer karena TestTimer dibuat ulang tiap scene reload
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
