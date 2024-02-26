using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] q = GameObject.FindGameObjectsWithTag("CS");
        GameObject qwe  = q[q.Length - 1];
        CharSelHandler qw = qwe.GetComponent<CharSelHandler>();
        Debug.LogError(qw.p1);
        Debug.LogError(qw.p2);
        //GameObject.Find("P1" + qw.p1).SetActive(true);
        //GameObject.Find("P2" + qw.p2).SetActive(true);
        foreach (GameObject qo in GameObject.FindGameObjectsWithTag("Player"))
        {
            Debug.Log(qo.name);
            if (qo.name != "P1" + qw.p1 && qo.name != "P2" + qw.p2)
            {
                qo.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
