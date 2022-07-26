
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ship : MonoBehaviour
    {
        public float speed = 10.0f;
        private Rigidbody r;
        //                                    w        s       a    d       q      e
        private bool[] movement = new bool[]{false, false, false, false, false, false};

        public void wD(Hand fromHand){
           down(0, fromHand);
        }

        public void wU(Hand fromHand){
           up(0, fromHand);
        }

        public void sD(Hand fromHand){
           down(1, fromHand);
        }

        public void sU(Hand fromHand){
           up(1, fromHand);
        }

        public void aD(Hand fromHand){
           down(2, fromHand);
        }

        public void aU(Hand fromHand){
           up(2, fromHand);
        }

        public void dD(Hand fromHand){
           down(3, fromHand);
        }

        public void dU(Hand fromHand){
           up(3, fromHand);
        }

        public void qD(Hand fromHand){
           down(4, fromHand);
        }

        public void qU(Hand fromHand){
           up(4, fromHand);
        }

        public void eD(Hand fromHand){
           down(5, fromHand);
        }

        public void eU(Hand fromHand){
           up(5, fromHand);
        }

        private void down(int i, Hand fromHand){
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            movement[i] = true;
        }

        private void up(int i, Hand fromHand){
            ColorSelf(Color.white);
            fromHand.TriggerHapticPulse(1000);
            movement[i] = false;
        }

        private void Move(){
            if (movement[0]){
                r.velocity = transform.forward * speed;
            } else if (movement[1]) {
                r.velocity = -transform.forward * speed;
            }

            if (movement[2] && !movement[3]){
                r.velocity = transform.right * speed;
            } else if (movement[3]) {
                r.velocity = -transform.right * speed;
            }

            if (movement[2] && !movement[3]){
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
            } else if (movement[3]) {
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);
            }
        }
        

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }

         private void Start()
        {
           r.GetComponent<Rigidbody>();
        }
    }
    
}