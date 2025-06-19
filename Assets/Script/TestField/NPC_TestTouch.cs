using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_TestTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("NPC touched player!");

            // Stop the timer
            TestTimer.Instance.StopTimer();

            // Show the Game Over Menu
            TestOverMenu.Instance.ShowTestOver();
        }
    }
}
