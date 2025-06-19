using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocWall : MonoBehaviour
{
    public LastWall lastWallScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lastWallScript.ActivateWall();
        }
    }
}
