using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour {

    public float speed = 0.005f;
    public float speedVertial = 0.005f;


    // a reference to the action
    public SteamVR_Action_Vector2 Move;
    public SteamVR_Action_Vector2 MoveUp;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    //reference to the sphere
    public GameObject Player;

    void Start(){

        Move.AddOnAxisListener(MovePlayer, handType);
        MoveUp.AddOnAxisListener(Up, handType);
    }

    private void Up(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta) 
    {
        Player.transform.position += new Vector3(0, axis.y * speedVertial, axis.x * -speedVertial);
    
    }

    private void MovePlayer(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta){
        
        Player.transform.position += new Vector3(axis.y * speed, 0, axis.x * -speed);

    }
}