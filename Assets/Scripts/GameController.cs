using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player_1;
    public GameObject Player_2;
    public GameObject FoamCup;
    public Camera Main_Camera;

    private bool First_Player_Turn;
    private Vector3 Throw_Vector;
    private bool Pong_Exists;

    GameObject Other_Player;
    public float shakeMagnetude = 0.0001f, shakeTime = 0.1f;
    Vector3 cameraInitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        First_Player_Turn = true;
        Pong_Exists = false;
        Other_Player = Player_1;
        Main_Camera.transform.position = Player_1.transform.position;
        Main_Camera.transform.rotation = Player_1.transform.rotation;
        setCups();
    }

    //public void ShakeIt()
    //{
    //    cameraInitialPosition = Main_Camera.transform.position;
    //    InvokeRepeating("StartCameraShaking", 0f, 2f);
    //    //Invoke("StopCameraShaking", shakeTime);
    //}

    //void StartCameraShaking()
    //{
    //    float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
    //    float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
    //    Vector3 cameraIntermadiatePosition = Main_Camera.transform.position;
    //    cameraIntermadiatePosition.x += cameraShakingOffsetX;
    //    cameraIntermadiatePosition.y += cameraShakingOffsetY;
    //    Main_Camera.transform.position = cameraIntermadiatePosition;
    //}

    // Update is called once per frame
    void Update() {
        //ShakeIt();
        Handle_Keyboard();
        if (Pong_Exists)
        {
            Change_Player_Turn();
        }
        else
        {
            Handle_Camera_Change();
            Handle_Pong_Throw();
        }
    }

    private void Handle_Keyboard()
    {
        if (Input.GetKeyDown("r")) {
            restartGame();
        }
    }

    public void restartGame() {
        Start();
    }

    private void Handle_Pong_Throw() {
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

    private void Handle_Camera_Change() {
        Main_Camera.transform.position = Vector3.Lerp(Main_Camera.transform.position, Other_Player.transform.position, 0.04f);
        Main_Camera.transform.rotation = Quaternion.Slerp(Main_Camera.transform.rotation, Other_Player.transform.rotation, 0.04f);
    }

    private void Change_Player_Turn()
    {
        if (GameObject.Find("Pong(Clone)") == null)
        {
            if (First_Player_Turn)
            {
                Other_Player = Player_2;
            }
            else
            {
                Other_Player = Player_1;
            }
            First_Player_Turn = !First_Player_Turn;

            var foamCup = GameObject.FindGameObjectsWithTag("FoamCup");
            foreach (var obj in foamCup)
            {
                obj.transform.rotation = new Quaternion(0, 90, 90, 0);
            }

            Pong_Exists = false;
        }
    }

    private void setCups() {
        var foamCup = GameObject.FindGameObjectsWithTag("FoamCup");
        foreach (var obj in foamCup) {
            Destroy(obj);
        }

        Instantiate(FoamCup, new Vector3(0f, 10f, 1.25f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(0.5f, 10f, 2.25f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(-0.5f, 10f, 2.25f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(1f, 10f, 3f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(-1f, 10f, 3f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(0f, 10f, 3f), new Quaternion(0, 90, 90, 0));

        Instantiate(FoamCup, new Vector3(0f, 10f, -1.25f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(0.5f, 10f, -2.25f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(-0.5f, 10f, -2.25f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(1f, 10f, -3f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(-1f, 10f, -3f), new Quaternion(0, 90, 90, 0));
        Instantiate(FoamCup, new Vector3(0f, 10f, -3f), new Quaternion(0, 90, 90, 0));
    }
}
