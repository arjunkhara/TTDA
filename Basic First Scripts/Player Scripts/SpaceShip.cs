using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    Rigidbody RB;
    public float upForce;
    private float MovementForwardSpeed = 10.0f;
    private float tiltAmountForward = 0;
    private float tiltVelocityForward = 0;

    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountbyKeys = 2.5f;
    private float rotationYVelocity;

    private Vector3 velocityToSmoothDampToZero;

    private float sideMovementAmount = 1f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void MovementUpDown()
    {
        if (Input.GetMouseButton(2) && Input.GetMouseButton (0))
        {
            Debug.Log("is Rising");
            upForce = 100;
        }

        else if(Input.GetMouseButton(2) && Input.GetMouseButton(1))
        {
            upForce = -100;
            Debug.Log("is lowering");
        }

        else 
        {
            Debug.Log("is still");
            upForce = 0;
        }

       
    }

    void Rotation() {
        if(Input.GetKey(KeyCode.A))
        {
            wantedYRotation -= rotateAmountbyKeys;
        }

        if (Input.GetKey(KeyCode.D))
        {
            wantedYRotation += rotateAmountbyKeys;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    void MovementForward()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            RB.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * MovementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 10 * Input.GetAxis("Vertical"), ref tiltAmountForward, 0.1f);
        }
    }

    private void FixedUpdate()
    {

        MovementUpDown();
        MovementForward();
        Rotation();
        ClampSpeedValues();
        Swerve();
        RB.AddRelativeForce(Vector3.up * upForce * Time.deltaTime);
        RB.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));
    }

    void Swerve()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            RB.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }

    void ClampSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, Mathf.Lerp(RB.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, Mathf.Lerp(RB.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, Mathf.Lerp(RB.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            RB.velocity = Vector3.SmoothDamp(RB.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }

    }



}

/* private float speed = 0.5f;
    public float coefficient = 0.1f;
    public float offset = 5;

    public Vector3 direction = new Vector3(0, 1, 0);
    private Vector2 movement;

    float startTime;


    private void Start()
    {
        startTime = Time.time;

    }

    private void MovementUpDown()
    {
        if (Input.GetMouseButton(2) && Input.GetMouseButton (0))
        {
            var deltaTime = Time.time - startTime;

            speed = coefficient * deltaTime + offset;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if(Input.GetMouseButton(2) && Input.GetMouseButton(1))
        {
            var deltaTime = Time.time - startTime;

            speed = coefficient * deltaTime - offset;
            transform.Translate(direction * speed * Time.deltaTime); ;
        }
    }


    private void Update()
    {

        MovementUpDown();
    }
*/
