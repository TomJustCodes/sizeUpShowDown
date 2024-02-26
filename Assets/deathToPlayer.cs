using System.Collections;
using System.Collections.Generic;
using Assets;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class deathToPlayer : MonoBehaviour
{

    public Collider deathboxCollider;

    public Transform respawnPoint;

    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        // players = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // foreach (GameObject player in players)
        // {
        //     if (deathboxCollider.bounds.Contains(player.transform.position))
        //     {
                

        //     }

    }

    void respawnPlayer(GameObject player){

        player.GetComponent<Transform>().position = respawnPoint.position;
        player.GetComponent<PlayerVitalsController>().lives -= 1;


            int lives = player.GetComponent<PlayerVitalsController>().lives;

            player.GetComponent<PlayerVitalsController>().percent = 0;
            player.GetComponent<PlayerVitalsController>().setLives(lives);
        
        
        
    }

    void killPlayer(GameObject player){
        player.SetActive(false);
        player.GetComponent<PlayerVitalsController>().setLives(0);

        //manger finshes games
    }

    void OnTriggerEnter(Collider col) {
        GameObject player = col.gameObject;
if (player.GetComponent<PlayerVitalsController>().lives > 1)
                {

                    respawnPlayer(player);
                }
                else
                {
                    killPlayer(player);
                }
    
    }
}
