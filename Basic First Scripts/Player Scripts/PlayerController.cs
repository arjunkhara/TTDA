using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movespeed;
    private string MovementAxisName;
    private string LeftRightAxisName;
    private Rigidbody rb;
    private float MovementInputValue;
    private float LeftRightInputValue;

    public GameObject Drone;
    LevelManager LM;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MovementInputValue = 0f;
        LeftRightInputValue = 0f;
        LM = FindObjectOfType<LevelManager>();
 
    }

    private void Start()
    {
        MovementAxisName = "Vertical";
        LeftRightAxisName = "Horizontal";
    }

    private void Update()
    {

        if(LM.IsthereaDrone == true)
        {
            Drone.SetActive(true);
            movespeed = 0;
        }

        else if(LM.IsthereaDrone == false)
        {
            Drone.SetActive(false);
            movespeed = 5;
        }
        MovementInputValue = Input.GetAxis(MovementAxisName);
        LeftRightInputValue = Input.GetAxis(LeftRightAxisName);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = transform.forward * MovementInputValue * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        Vector3 LeftRight = transform.right * LeftRightInputValue * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + LeftRight);
    }
}
