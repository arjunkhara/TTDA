using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

    public int count;

    public GameObject Sparks;
    public GameObject Smoke;
    public GameObject Fire;


	void Start () {
        count = 0;
        Sparks.SetActive(false);
        Smoke.SetActive(false);
        Fire.SetActive(false);
	}
	
	void Update () {
        if(count == 1)
        {
            Sparks.SetActive(true);
        }

        if(count == 2)
        {
            Smoke.SetActive(true);
        }

        if(count == 3)
        {
            Fire.SetActive(true);
        }
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            count += 1;
        } 
    }
}
