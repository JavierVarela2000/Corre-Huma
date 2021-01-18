using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler sharedInstance; // singleton

    public float jumpForce = 215f;
    public float RightImpulse = 0f;
    //public float downimpulse = 5f;
    public float jumpImpulse = 11500f;
    public Animator animator;
    //private int clickcontrol = 0;
    public float runningSpeed = 70f;
    //public float groundDistance = 0f;
    


    private Rigidbody2D rigibody;
    // Start is called before the first frame update


    private void Awake()
    {
        sharedInstance = this; // singleton
        rigibody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       animator.SetBool("isGrounded" , false);
       animator.SetBool("isAtack",false);
        animator.SetBool("GamePause", true);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame) // solo si esta en juego
        {
            if (Input.GetButtonDown("Saltar"))
            {
                //clickcontrol++;
                Jump();

            }
            animator.SetBool("isGrounded", IsTouchingTheGround());//animacion de caida y vuelo

        }

        

        

        //fuerza continua si no deja de presionar space
       
        //impulso hacia abajo si cuando levanta space
       /* if (Input.GetKeyUp(KeyCode.Space) && clickcontrol > 1)
        {
            rigibody.AddForce(Vector2.down * downimpulse, ForceMode2D.Impulse);
        }*/




    }

    void FixedUpdate()
    {

        //velocidad hacia la derecha
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            animator.SetBool("GamePause",false); 
            if (rigibody.velocity.x < runningSpeed)
            {
                rigibody.velocity = new Vector2(runningSpeed, rigibody.velocity.y);
            }

            //subida y planeo
            if (Input.GetButton("Saltar"))
            {


                rigibody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);


            }

            if (Input.GetButtonDown("Fuego") && IsTouchingTheGround())
            {
                
                animator.SetBool("isAtack", true);
            }
            else
            {
                animator.SetBool("isAtack", false);
            }
        }
        else
        {
            animator.SetBool("GamePause", true);
        }

        /*if (IsTouchingTheEnemy())// si toca un enemigo te lanza hacia atras 
        {
            rigibody.AddForce(Vector2.up * 3000f, ForceMode2D.Impulse);
            rigibody.AddForce(Vector2.left * 60000f, ForceMode2D.Impulse);
        }*/

    }


    void Jump()
    {
        if (IsTouchingTheGround())
        {
        rigibody.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        rigibody.AddForce(Vector2.right * RightImpulse, ForceMode2D.Impulse);
        }
    }

    public LayerMask groundLayer; // detecta la capa del suelo
    bool IsTouchingTheGround()//devuelve T si toca el suelo F si no
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 24f, groundLayer))
        {
            //this.clickcontrol = 0;
            return true;
            
            
        }
        else
        {
            return false;
        }
    }
    public LayerMask enemyLayer;//capa del enemigo
    public bool IsTouchingTheEnemyAtack()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.right, 28f, enemyLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsTouchingTheEnemy() {
        if(Physics2D.Raycast(this.transform.position, Vector2.right, 10f, enemyLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}