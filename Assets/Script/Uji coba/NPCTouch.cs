using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDeath playerDeath = collision.GetComponent<PlayerDeath>();
            if (playerDeath != null)
            {
                playerDeath.TriggerDeath();
            }
        }
    }
}
