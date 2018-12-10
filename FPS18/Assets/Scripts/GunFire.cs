using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    AudioSource gunsound;
    public static int shotsFired;

	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            gunsound = GetComponent<AudioSource>();
            gunsound.Play();
            shotsFired += 1;
        }
	}
}
