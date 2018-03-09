using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MonsterPatrol))]
public class AggressiveEnemyChase : MonoBehaviour {


    public Transform player;
    public float playerDistance;
    public float rotationDampling;
    public float moveSpeed;
    public float lookDistance;
    public float chaseDistance;
    public float stopChaseDistance;
    MonsterPatrol MP;


    private void Start()
    {
        MP = GetComponent<MonsterPatrol>();
    }

    void Update()
    {

        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < lookDistance)
        {
            lookAtPlayer();
        }

        if (playerDistance < chaseDistance)
        {

            chase();
            MP.enabled = false;
        }

        if (playerDistance > stopChaseDistance)
        {
            MP.enabled = true;
        }

    }

    void lookAtPlayer()
    {

        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}
