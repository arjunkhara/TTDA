using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour {

    public float rotationSpeed = 99.0f;
    public bool reverse = false;
    PlayerController PC;

    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) {
                //transform.Rotate(Vector3.back * Time.deltaTime * this.rotationSpeed);
                transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime * this.rotationSpeed);
            PC.movespeed = 0;
        }
        else
        {
            PC.movespeed = 5;
        }

        
    }


    public void SetRotationSpeed(float speed)
    {
        this.rotationSpeed = speed;
    }

    public void SetReverse(bool reverse)
    {
        this.reverse = reverse;
    }
}
