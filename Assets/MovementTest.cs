using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float speed;
    private Vector3 targetPos;

    public GameObject jalur;
    public Transform[] wayPoints;
    
    private int pointIndex;
    private int pointCount;
    private int direction = 1;

    public float waitDuration;
    int speedMultiplier = 1;


    private void Awake()
    {
        wayPoints = new Transform[jalur.transform.childCount];
        for (int i = 0; i < jalur.transform.childCount; i++)
        {
            wayPoints[i] = jalur.transform.GetChild(i);
        }
    }

    private void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 0; 
        targetPos = wayPoints[pointIndex].position;
    }

    private void Update()
    {
        var step = speedMultiplier*speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (transform.position == targetPos)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].position;
        StartCoroutine(WaitNextPoint());


    }

    IEnumerator WaitNextPoint(){
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}