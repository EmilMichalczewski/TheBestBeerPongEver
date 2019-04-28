using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBehaviour : MonoBehaviour {

	public GameObject Player_Emitter;
	public GameObject Pong;
	public float Pong_Forward_Force;
    public bool Is_First_Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Throw_Pong(Vector3 Throw_Vector) {
        Throw_Vector.x = Throw_Vector.x * -1 * Get_Player_Factor();
        Throw_Vector.z = (Throw_Vector.y * -1) * Pong_Forward_Force * Get_Player_Factor();
        Throw_Vector.y = 20f;

        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Pong, Player_Emitter.transform.position, Player_Emitter.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(Throw_Vector);
        Destroy(Temporary_Bullet_Handler, 10.0f);
    }

    int Get_Player_Factor() {
        if (Is_First_Player) {
            return 1;
        }
        return -1;
    }
}
