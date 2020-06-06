using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour
{

	private GameControlScript control;
	//public float objectSpeed = -.3f;



	// Use this for initialization
	void Start () {
		control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(0, 0, control.objectSpeed);
		transform.Translate(0, 0, control.objectSpeed);
	}

	
}
