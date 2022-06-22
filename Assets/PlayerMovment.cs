using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{

    public Rigidbody2D my_Rigidbody;

    public Text TextFieldScore;
    public float speedFactor = 200f;
    public float jumpForce = 25000.0f;
    public Vector2 jump;
    public bool isGrounded = true;
    public float score = 0;
    public bool DEBUG = false;
    public bool enableDoubleJump = false;
    public AudioSource jumpSound;
    public AudioSource doubleJumpSound;
    public AudioSource dieSound;
    public bool enableJump = true;

        
    // Start is called before the first frame update
    void Start()
    {

        my_Rigidbody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        // make player fall down faster
        if (my_Rigidbody.velocity.y < 0)
        {
            my_Rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (1.0f - my_Rigidbody.velocity.y / 10.0f) * Time.deltaTime;
        }

    }

    // void OnCollisionEnter (Collider target)
    // {
    //  isGrounded = true;
    //   if(target.gameObject.tag.Equals("barrel_open_rolling") == true )
    //   {
    //        Debug.Log("Collide");
    //   }
    // }

    void OnCollisionEnter2D(Collision2D hit)
    {
        isGrounded = true;
        enableDoubleJump = false;
        if(hit.transform.gameObject.name != "ground")
        {
            Debug.Log("Collide");
            if (!DEBUG){
                dieSound.Play();
                //stop player
                my_Rigidbody.velocity = new Vector2(0, 0);
                // throw player in the air
                my_Rigidbody.AddForce(jump * jumpForce*2);
                // make player fall trough the ground
                my_Rigidbody.AddForce(Vector2.down * jumpForce*2);

                my_Rigidbody.velocity = new Vector2(-20, 0);
                 SceneManager.LoadScene("MainMenu");
                // StartCoroutine(playerDie());
            }
        }
    }

    // IEnumerator playerDie()
    // {
    //     // yield return new WaitForSeconds(3.5f);
       
    // }


    // Update is called once per frame
    void Update()
    {
        my_Rigidbody.velocity = new Vector2(speedFactor,my_Rigidbody.velocity.y);
        if (enableJump){
            if (Input.GetKeyDown("space") && isGrounded)
            {   
                // my_Rigidbody.velocity = new Vector2(my_Rigidbody.velocity.x, jumpForce);
                my_Rigidbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
                enableDoubleJump = true;
                // add a sound effect
                jumpSound.Play();
                
            }
            //Implement double jump
            else if (Input.GetKeyDown("space") && !isGrounded && enableDoubleJump)
            {
                my_Rigidbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                enableDoubleJump = false;
                isGrounded = false;
                doubleJumpSound.Play();
            }
        }

        score++;
        TextFieldScore.text = "Score: " + ((int)(score/10)).ToString();
        // increase speed of the player proportional to the score
        speedFactor = 200f + (score/100);
        //increase jump force proportional to the score
        jumpForce = 25000.0f + (score/100);
    }
}