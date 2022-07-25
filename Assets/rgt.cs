//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    public class rgt : MonoBehaviour
    {   
        public GameObject plat;

        private bool going = false;

        public void onButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            going = true;
        }

        public void onButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
            going = false;
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }

        private void Update()
        {
            if (going) {
                plat.transform.position += plat.transform.TransformDirection(Vector3.up);
            
            }
        }
    }
}