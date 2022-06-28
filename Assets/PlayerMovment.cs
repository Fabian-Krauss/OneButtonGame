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
    public drinkBeer beerScript;
    public SpriteRenderer spriteRenderer;
    private float hue;
    private float sat;
    private float bri;
    private float timeAtJump = 0.0f;
    public float timeBetweenJumps = 0.5f;
    // private float rainbowSpeed = 0.1f;
    // private float rainbowTime = 0.0f;

        
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
            if (!DEBUG){
                if(!beerScript.zerfickerModus){
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
                else{
                    Destroy(hit.transform.gameObject);
                }
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
                timeAtJump = Time.realtimeSinceStartup;
                
            }
            //Implement double jump
            else if (Input.GetKeyDown("space") && !isGrounded && enableDoubleJump)
            {
                if(Time.realtimeSinceStartup - timeAtJump > timeBetweenJumps ){
                       my_Rigidbody.velocity = new Vector2(my_Rigidbody.velocity.x,0);
                    my_Rigidbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                    enableDoubleJump = false;
                    isGrounded = false;
                    doubleJumpSound.Play();
                }
            }
        }
        if(beerScript.zerfickerModus){
            Color.RGBToHSV(spriteRenderer.color, out hue, out sat, out bri);
            hue += 0.01f;
            sat = 1;
            bri = 1;
            spriteRenderer.color = Color.HSVToRGB(hue, sat, bri);
        }
        else{
            spriteRenderer.color = Color.white;
        }

        score++;
        TextFieldScore.text = "Score: " + ((int)(score/10)).ToString();
        // increase speed of the player proportional to the score
        speedFactor = 200f + (score/300);
        //increase jump force proportional to the score
        // jumpForce = 25000.0f + (score/300);
    }
}