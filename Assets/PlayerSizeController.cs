using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeController : MonoBehaviour
{
    public static KeyCode[,] key = new KeyCode[,]
    {
        {KeyCode.Alpha1, KeyCode.Alpha2,KeyCode.Alpha3,},
        {KeyCode.Alpha8, KeyCode.Alpha9,KeyCode.Alpha0,},
    };
    public int playercode = 0;
    public int size = 1;
    Vector3 intSize = new Vector3(1, 1, 1);
    Vector3 initSize;
    PlayerController pc;

    private bool prevu = false;
    private bool prevd = false;

    // Start is called before the first frame update
    void Start()
    {
        intSize = transform.localScale;
        initSize = transform.localScale;
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Up") == 0)
        {
            prevu = false;
        }
        if (Input.GetAxis("Down") == 0)
        {
            prevd = false;
        }
        if (playercode == 1 && Input.GetAxis("Up") == 1 && !prevu)
        {
            prevu = true;
            size += 1;
            if (size == 3)
            {
                size = 2;
            }
        }
        else if (playercode == 1 && Input.GetAxis("Down") == 1 && !prevd)
        {
            prevd = true;
            size -= 1;
            if (size == -1)
            {
                size = 0;
            }
        }

        if (playercode == 1)
        {
            if (size == 0)
            {
                intSize = initSize * 0.3f;
            }
            else if (size == 1)
            {
                intSize = initSize * 1f;
            }
            else
            {
                intSize = initSize * 2f;
            }
        }

        if (transform.localScale.z < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
        }
        transform.localScale -= (transform.localScale - intSize) / 10;
        if (pc.dir == -1)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
        }

        if (playercode == 0 &&  Input.GetKeyDown(key[playercode, 0]))
        {
            intSize = initSize * 0.3f;
            size = 0;
        }
        if (playercode == 0 && Input.GetKeyDown(key[playercode, 1]))
        {
            intSize = initSize * 1f;
            size = 1;
        }
        if (playercode == 0 && Input.GetKeyDown(key[playercode, 2]))
        {
            intSize = initSize * 2f;
            size = 2;
        }

    }
}
