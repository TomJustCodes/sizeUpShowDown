using Assets.Chars.Key;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets
{
   
    public class KeyMovement : GenericMovement
    {
        bool inSmall = false;
        private GameObject Keyboard1;
        private GameObject Keyboard2;
        private GameObject Mouse;
        private GameObject Keys;
        private GameObject mplayer;
        private GameObject Letter;
        public KeyMovement(GameObject player) 
        {
            Keyboard1 = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Attack");
            Keyboard2 = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Attack1");
            Mouse = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Attack2");
            Keys = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Attack3");
            Letter = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Attack4");

            mplayer = player;
        }
        public override void handleBasicInAir(int x, int y, int size)
        {

            if (inSmall)
            {
               inSmall = false;
                try
                {
                    mplayer.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                }
                catch
                {

                }

                try
                {
                    mplayer.GetComponentInChildren<MeshRenderer>().enabled = true;
                }
                catch
                {

                }
                mplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
                Letter.transform.position = mplayer.transform.position;


                Letter.GetComponentInChildren<PunchController>().waitToDelete();

            }
            else
            {
                Mouse.transform.position = mplayer.transform.position;
                Mouse.transform.localRotation = Quaternion.EulerAngles(-1f, 0, 0);

                Mouse.GetComponentInChildren<PunchController>().waitToDelete();
            }
            

            

        }
        public override void handleBasicOutAir(int x, int y, int size)
        {
            if (inSmall)
            {
                inSmall = false;
                try
                {
                    mplayer.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                }
                catch
                {

                }

                try
                {
                    mplayer.GetComponentInChildren<MeshRenderer>().enabled = true;
                }
                catch
                {

                }
                mplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
                Letter.transform.position = mplayer.transform.position;


                Letter.GetComponentInChildren<PunchController>().waitToDelete();
            }
            else
            {


                //Debug.LogError(x);
                //Debug.LogError(y);
                if (x == 0 && y == -1)
                {
                    Debug.LogError("qweqwe");
                    foreach (Transform t in Keys.GetComponentsInChildren<Transform>())
                    {
                        t.transform.position = mplayer.transform.position + new Vector3(0, 1, UnityEngine.Random.Range(-10f, 10f) / 10);
                    }
                    //Key toss
                    foreach (PunchController pc in Keys.GetComponentsInChildren<PunchController>())
                    {
                        pc.waitToDelete();
                    }
                    foreach (KeyController pc in Keys.GetComponentsInChildren<KeyController>())
                    {
                        pc.addForce();
                    }
                }
                else
                {
                    if (x == 1 || x == 0 && mplayer.transform.localScale.z > 0)
                    {
                        Keyboard1.transform.position = mplayer.transform.position;
                        Keyboard1.transform.localRotation = Quaternion.EulerAngles(0.1f, 0, 0);
                        if (size == 0)
                        {
                            Keyboard1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        }
                        else if (size == 1)
                        {
                            Keyboard1.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            Keyboard1.transform.localScale = new Vector3(3f, 3f, 3f);
                        }
                        Keyboard1.GetComponentInChildren<PunchController>().waitToDelete();
                    }
                    else
                    {
                        Keyboard2.transform.position = mplayer.transform.position;
                        Keyboard2.transform.localRotation = Quaternion.EulerAngles(-0.1f, 0, 0);

                        Keyboard2.GetComponentInChildren<PunchController>().waitToDelete();
                    }

                }
            }



        }
        public override void handleSpecialInAir(int x, int y, int size)
        {
            //Redice size
            //on attack
            //do big letter hitbox
            Debug.LogError("qwe");
            inSmall = true;
            try
            {
                mplayer.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            }
            catch
            {

            }

            try
            {
                mplayer.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            catch
            {

            }


            mplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        public override void handleSpecialOutAir(int x, int y, int size)
        {
            //Redice size
            //on attack
            //do big letter hitbox
            inSmall = true;

            try
            {
                mplayer.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            }
            catch
            {

            }

            try
            {
                mplayer.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            catch
            {

            }

            mplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }

    }
}
