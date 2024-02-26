using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Assets.Chars.Key;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets
{
    public class dummyMovement : GenericMovement
    {
        private GameObject Punch;
        private GameObject Punch1;
        private GameObject Uppercut;
        private GameObject kick;
        private GameObject kick2;


        private GameObject mplayer;
        private Animator ani;

        public dummyMovement(GameObject player)
        {
            //Debug.Log(player);
            Punch = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Punch");
            Punch1 = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Punch1");
            Uppercut= GameObject.Find(player.GetComponent<PlayerController>().playercode + "Up");
            kick = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Kick");
            kick2 = GameObject.Find(player.GetComponent<PlayerController>().playercode + "Kick2");
            Debug.Log(mplayer);
            ani = player.GetComponent<Animator>();

            mplayer = player;
        }

        public override void handleBasicInAir(int x, int y, int size)
        {      
            ani.SetTrigger("kick");
             if (x == 1 || x == 0 && mplayer.transform.localScale.z > 0){
                 kick.transform.position = mplayer.transform.position;
                        if (size == 0)
                        {
                            Punch1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        }
                        else if (size == 1)
                        {
                            Punch1.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            Punch1.transform.localScale = new Vector3(2f, 2f, 2f);
                        }
                    kick.GetComponentInChildren<PunchController>().waitToDelete();
             }
                else
                {
                    kick2.transform.position = mplayer.transform.position;
                            if (size == 0)
                            {
                                Punch1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            }
                            else if (size == 1)
                            {
                                Punch1.transform.localScale = new Vector3(1f, 1f, 1f);
                            }
                            else
                            {
                                Punch1.transform.localScale = new Vector3(2f, 2f, 2f);
                            }
                        kick2.GetComponentInChildren<PunchController>().waitToDelete();
                }
        }

        public override void handleBasicOutAir(int x, int y, int size)
        {
            if (x == 0 && y == -1)
            {
                ani.SetTrigger("uppercut");
                Uppercut.transform.position = mplayer.transform.position;
                        if (size == 0)
                        {
                            Uppercut.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        }
                        else if (size == 1)
                        {
                            Uppercut.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            Uppercut.transform.localScale = new Vector3(2f, 2f,2f);
                        }
                    Uppercut.GetComponentInChildren<PunchController>().waitToDelete();
            }
            else
            {
                ani.SetTrigger("Punch");
                if (x == 1 || x == 0 && mplayer.transform.localScale.z > 0)
                {
                    Punch.transform.position = mplayer.transform.position;
                        if (size == 0)
                        {
                            Punch.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        }
                        else if (size == 1)
                        {
                            Punch.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            Punch.transform.localScale = new Vector3(2f, 2f, 2f);
                        }
                    Punch.GetComponentInChildren<PunchController>().waitToDelete();
                }
                else
                {
                    Punch1.transform.position = mplayer.transform.position;
                        if (size == 0)
                        {
                            Punch1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        }
                        else if (size == 1)
                        {
                            Punch1.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            Punch1.transform.localScale = new Vector3(2f, 2f, 2f);
                        }
                    Punch1.GetComponentInChildren<PunchController>().waitToDelete();
                }
            }
        }

        public override void handleSpecialInAir(int x, int y, int size) { }

        public override void handleSpecialOutAir(int x, int y, int size) { }
    }
}
