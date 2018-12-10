using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTarget : MonoBehaviour {

    public float speed = 5f;
    public float n;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        n = -speed * Time.deltaTime;
        
        transform.Translate(0, 0, n);

        //if (n <= 15.5)
        //{
        //    transform.translate(0, 0, n);
        //}

    }
}
