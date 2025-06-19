using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExecutionLog : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AStarManager.instance.SaveTimesToFile();
            Debug.Log("Data waktu disimpan ke file.");
        }
    }
}
