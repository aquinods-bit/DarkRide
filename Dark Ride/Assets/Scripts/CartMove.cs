using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCart : MonoBehaviour
{
    public GameObject[] wayPoints;
    private int index = 0;

    private float speed = 10;

    void Update()
    {
        if (index >= wayPoints.Length)
            return;

        float distance = Vector3.Distance(
            transform.position,
            wayPoints[index].transform.position
        );

        if (distance < 0.5f)
        {
            index++;

            if (index >= wayPoints.Length)
            {
                speed = 0;
                Debug.Log("Reached final waypoint!");
                return;
            }
        }

        // Movement
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(
            transform.position,
            wayPoints[index].transform.position,
            step
        );

        // Rotation that supports loops and prevents spinning
        Vector3 direction = wayPoints[index].transform.position - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(
                direction,
                wayPoints[index].transform.up
            );

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * 5f
            );
        }
    }
}