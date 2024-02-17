using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPostioning : MonoBehaviour
{
    public Transform[] playersPos;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        playersPos = new Transform[allPlayers.Length];
        for(int i = 0; i < allPlayers.Length; i++){
            playersPos[i] = allPlayers[i].transform;
        }
    }

    public float yoffset = 2.0f;
    public float minDistance = 7.5f;
    private float xMin, xMax, yMin, yMax;

    private void LateUpdate(){

        if(playersPos.Length == 0){
            Debug.Log("nah bro");
        }

        xMin = xMax = playersPos[0].position.z;
        yMin = yMax = playersPos[0].position.y;

        for( int i = 1; i < playersPos.Length; i++){
            if(playersPos[i].position.z < xMin){
                xMin = playersPos[i].position.z;
            }
            if(playersPos[i].position.z > xMax){
                xMax = playersPos[i].position.z;
            }
            if(playersPos[i].position.y < yMin){
                yMin = playersPos[i].position.y;
            }
            if(playersPos[i].position.y > yMax){
                yMax = playersPos[i].position.y;
            }
        }

        float xMiddle = (xMin + xMax) / 2;
        float yMiddle = (yMin + yMax) / 2;
        float distance = xMax - xMin;
        if(distance < minDistance){
            distance = minDistance;
        
        }

        transform.position = new Vector3(distance-60, yMiddle + yoffset, xMiddle );


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
