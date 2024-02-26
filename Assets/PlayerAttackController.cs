using Assets;
using System.Collections;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public GenericMovement movement;
    private PlayerController player;
    private PlayerSizeController playerSizeController;
    public int playercode;
    private Animator ani;



    private int downBefJ = 0;
    private int downBefN = 0;

    public bool blocking = false;
    private bool canBlock = true;

    public bool brawler;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        playerSizeController = GetComponent<PlayerSizeController>();
        ani = GetComponent<Animator>();

        if(brawler == true
            )
        {
            movement = new dummyMovement(gameObject);
        }
        else
        {
            movement = new KeyMovement(gameObject);
        }
    }

    public static KeyCode[,] key = new KeyCode[,]
    {
        {KeyCode.LeftArrow, KeyCode.RightArrow,KeyCode.LeftShift},

    };

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") == 0 && downBefJ == 1)
        {
            downBefJ = 0;
            Debug.Log("reset");
        }
        if (Input.GetAxis("Fire3") == 0 && downBefN == 1)
        {
            downBefN = 0;
            Debug.Log("reset");
        }



        //Debug.Log("HELLO WORLD");
        if (playercode == 0 && Input.GetKeyDown(key[playercode, 0]) || 
            playercode == 1 && Input.GetAxis("Fire2") == 1 && downBefJ == 0||
            playercode == 1 && Input.GetKeyDown(KeyCode.P))
        {
            downBefJ = 1;
            Debug.Log(player.no);
            if (player.no == 0)
            {
                movement.handleBasicInAir(player.addx, player.addy, playerSizeController.size);
            }
            else
            {
                movement.handleBasicOutAir(player.addx, player.addy, playerSizeController.size);
            


            }
        }
        if (playercode == 0 && Input.GetKeyDown(key[playercode, 1]) ||
           playercode == 1 && Input.GetAxis("Fire3") == 1 && downBefN == 0
           )
        {
            downBefN = 1;
            if (player.no != 0)
            {
                
                movement.handleSpecialInAir(player.addx, player.addy, playerSizeController.size);
            }
            else
            {
                movement.handleSpecialOutAir(player.addx, player.addy, playerSizeController.size);
            }
        }

        if (!blocking && canBlock && (playercode == 0 && Input.GetKeyDown(key[playercode, 2]) || playercode == 1 && Input.GetAxis("Jump") == 1) )
        {
            Debug.LogError("DODGE");
            blocking = true;
            canBlock = false;
            StartCoroutine(setBlocking());
            StartCoroutine(setCanBlocking());
             ani.SetBool("block", true);
        }


        
    }
    IEnumerator setBlocking()
    {
        yield return new WaitForSeconds(1);
        blocking = false;
        Debug.LogError("UNBLOCK");
        ani.SetBool("block", false);
        //particle effect???

    }

    IEnumerator setCanBlocking()
    {
        yield return new WaitForSeconds(5);
        canBlock = true;
        Debug.LogError("UNSBLOCK");
        //particle effect???
    }


}
