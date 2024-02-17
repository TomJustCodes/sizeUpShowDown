using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jump;
    Rigidbody rb;
    public int ground = 0;
    public int addx = 0;
    public int addy = 0;
    public int no;
    Animator ani;
    public bool humanoid = true;
    public int dir;


    private int downbefj;
    private LayerMask groundmask;


    public int playercode = 0;

    public List<Vector3> sizes;


    public static KeyCode[,] key = new KeyCode[,]
    {
        {KeyCode.W, KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.Space},
        
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(p.currentActionMap.FindAction("U").IsPressed()    );


        Collider[] colliders;
        if (humanoid)
        {
            colliders = Physics.OverlapBox(
            transform.position - new Vector3(0, transform.lossyScale.y / 2, 0),
            new Vector3(0.1f, 0.1f, transform.lossyScale.z / 2),
            Quaternion.identity,
            groundmask = LayerMask.GetMask(new string[] { "Ground" })
            );
        }
        else
        {
            PlayerSizeController ps = GetComponent<PlayerSizeController>();
            Debug.Log(transform.position);
            Debug.Log(transform.position - new Vector3(0,0, 0));
            //PlayerSizeController ps = GetComponent<PlayerSizeController>();
            
            if (ps.size == 0)
            {
                colliders = Physics.OverlapBox(
            transform.position - sizes[0],
            new Vector3(0.1f, 2f, 2),
            Quaternion.identity,
            groundmask = LayerMask.GetMask(new string[] { "Ground" })
            );
            }
            else if (ps.size == 1)
            {
                colliders = Physics.OverlapBox(
          transform.position - sizes[1],
          new Vector3(0.1f, 2f, 2),
          Quaternion.identity,
          groundmask = LayerMask.GetMask(new string[] { "Ground" })
          );
            
            }
            else
            {
                colliders = Physics.OverlapBox(
          transform.position - sizes[2],
          new Vector3(0.1f, 2f, 2),
          Quaternion.identity,
          groundmask = LayerMask.GetMask(new string[] { "Ground" })
          );
            }
            
            Debug.Log(colliders.Length);
        }
            
        no = colliders.Length;

        ani.SetBool("land" , false);

        if (no > 0)
        {
            ground = 1;
            ani.SetBool("land" , true);
            
        }

        if (Input.GetAxis("Fire1") == 0 && downbefj == 1)
        {
            downbefj = 0;
        }
        if (playercode == 0 && Input.GetKeyDown(key[playercode, 4]) ||
          playercode == 1 && Input.GetAxis("Fire1") == 1 && downbefj == 0)
        {
            downbefj = 1;
            ani.SetTrigger("jump");
            if (ground > 0)
            {
                ground -= 1;
                rb.AddForce(0, jump, 0);
                
            }
            
        }

        if(addx != 0){
            ani.SetBool("walking" , true);
        }
        else{
           ani.SetBool("walking" , false);
        }
    }

    

    private void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        addx = 0;
        addy = 0;
        if (playercode == 0 && Input.GetKey(key[playercode, 1]) ||
            playercode == 1 && Input.GetAxis("Horizontal") < -0.5)
        {
            addx = -1;
            
        }
        if (playercode == 0 && Input.GetKey(key[playercode, 3]) ||
            playercode == 1 && Input.GetAxis("Horizontal") > 0.5)
        {
            addx = 1;
            
        }
        if (playercode == 0 && Input.GetKey(key[playercode, 0]) || 
            playercode == 1 && Input.GetAxis("Vertical") > 0.5)
        {
            addy = -1;
            
        }
        if (playercode == 0 && Input.GetKey(key[playercode, 2]) || 
            playercode == 1 && Input.GetAxis("Vertical") < -0.5)
        {
            addy = 1;
        }

        
            if (addx == 1)
            {
            dir = 1;
            }
            else if (addx == -1)
            {
            dir = -1;
            }
            
        

        //rb.AddForce(((speed * addy) - rb.velocity.x) * 10, 0, ((speed * addx) - rb.velocity.z) * 10);
        rb.AddForce(0, 0, ((speed * addx) - rb.velocity.z) * 10);
    }
}
