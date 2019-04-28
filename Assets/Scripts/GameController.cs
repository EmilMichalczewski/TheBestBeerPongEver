using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player_1;
    public GameObject Player_2;

    private bool First_Player_Turn;
    private Vector3 Throw_Vector;

    // Start is called before the first frame update
    void Start()
    {
        First_Player_Turn = true;
    }

    // Update is called once per frame
    void Update()
    {
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

            First_Player_Turn = !First_Player_Turn;
        }
    }
}
