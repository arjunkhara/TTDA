using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour {

    public GameObject Holo;

	void Start () {
        Holo.SetActive(false);
		
	}
	
	
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Holo.SetActive(true);
        }
        else
        {
            Holo.SetActive(false);
        }
		
	}
}
