using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrundScript : MonoBehaviour {

    public float speed = -2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
        if (transform.position.z <= -15f)
        {
            transform.Translate(0f, 0f, 12f);
        }
	}
}
