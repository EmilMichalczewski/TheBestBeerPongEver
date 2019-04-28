using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBehaviour : MonoBehaviour {

	public GameObject Player_1_Emitter;
	public GameObject Pong;
	public float Pong_Forward_Force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate (Pong, Player_1_Emitter.transform.position, Player_1_Emitter.transform.rotation) as GameObject;
			Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
			Temporary_RigidBody.AddForce(transform.forward * Pong_Forward_Force);
			//Temporary_RigidBody.AddForce(0f, 1f, 1f);
			Destroy (Temporary_Bullet_Handler, 10.0f);
		}
	}
}
