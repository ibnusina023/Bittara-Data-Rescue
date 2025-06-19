using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWall : MonoBehaviour
{
    public GameObject lastWall;
    // Start is called before the first frame update
    void Start()
    {
        lastWall.SetActive(false);
    }
   
    public void ActivateWall()
    {
        lastWall.SetActive(true);
    }
}
