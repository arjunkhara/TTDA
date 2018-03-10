using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Rigidbody Drone;
    public Transform SpawnDrone;
    public bool IsthereaDrone;

    public GameObject PlayerCamera;
    public PlayerController PC;
    CameraRotation ML;
    Hologram HG;

    void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        ML = FindObjectOfType<CameraRotation>();
        IsthereaDrone = false;
        HG = FindObjectOfType<Hologram>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2) && IsthereaDrone == false)
        {
            PlayerCamera.SetActive(false);
            IsthereaDrone = true;
            Drone.transform.position = SpawnDrone.transform.position;
            ML.enabled = false;
            HG.enabled = false;
        }

        else if (IsthereaDrone == true && Input.GetMouseButtonUp(2)) {

            PlayerCamera.SetActive(true);
            ML.enabled = true;
            IsthereaDrone = false;
            HG.enabled = true;
        }


    }
}
