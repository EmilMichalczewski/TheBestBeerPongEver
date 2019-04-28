using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player_1;
    public GameObject Player_2;
    public Camera Main_Camera;

    private bool First_Player_Turn;
    private Vector3 Throw_Vector;
    private bool Pong_Exists;

    // Start is called before the first frame update
    void Start()
    {
        First_Player_Turn = true;
        Pong_Exists = false;
    }

    // Update is called once per frame
    void Update() {
        if (Pong_Exists) {
            Handle_Throw_Phase();
        } else {
            Handle_Player();
        }
    }

    private void Handle_Player() {
        GameObject Current_Player;
        if (Input.GetMouseButtonDown(0)) {
            Throw_Vector = Input.mousePosition;
        } else if (Input.GetMouseButtonUp(0)) {
            if (First_Player_Turn) {
                Current_Player = Player_1;
            } else {
                Current_Player = Player_2;
            }

            Throw_Vector = Input.mousePosition - Throw_Vector;
            Current_Player.GetComponent<PongBehaviour>().Throw_Pong(Throw_Vector);

            Pong_Exists = true;
        }
    }

    private void Handle_Throw_Phase() {

        if (GameObject.Find("Pong(Clone)") == null) {
            GameObject Other_Player;

            if (First_Player_Turn)
            {
                Other_Player = Player_2;
            }
            else
            {
                Other_Player = Player_1;
            }

            Main_Camera.transform.position = Other_Player.transform.position;
            Main_Camera.transform.rotation = Other_Player.transform.rotation;

            First_Player_Turn = !First_Player_Turn;

            Pong_Exists = false;
        }
    }
}
