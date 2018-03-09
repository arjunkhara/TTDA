using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour {
    public float moveSpeed;
    public Transform[] PatrolPoints;
    private int CurrentPoint;

    void Start()
    {
        transform.position = PatrolPoints[0].position;
        CurrentPoint = 0;
    }


    void Update()
    {

        if (CurrentPoint >= PatrolPoints.Length)
        {
            CurrentPoint = 0;
        }

        if (transform.position == PatrolPoints[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[CurrentPoint].position, moveSpeed * Time.deltaTime);

    }
}
