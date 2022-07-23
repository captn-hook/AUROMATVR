using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Rotation : MonoBehaviour
{

    public float speed = 0.5f;
    public float speedVertial = 0.5f;


    // a reference to the action
    public SteamVR_Action_Vector2 Turn;
    public SteamVR_Action_Vector2 Roll;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    //reference to the sphere
    public GameObject Player;

    void Start()
    {

        Turn.AddOnAxisListener(Rotate, handType);
        Roll.AddOnAxisListener(Spin, handType);
    }

    private void Rotate(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {

        Player.transform.Rotate(axis.x * speed, axis.y * speed, 0);

    }

    private void Spin(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {

        Player.transform.Rotate(axis.x * speed, 0, axis.y * speed);

    }
}