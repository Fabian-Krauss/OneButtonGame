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
    public float jumpForce = 250.0f;
    public Vector2 jump;
    public bool isGrounded = true;
    public float score = 0;
    public ScoreScript scoreS;
    public xPosScript xPosS;
    public bool DEBUG = false;
    public bool enableDoubleJump = false;
    public AudioSource jumpSound;
    public AudioSource doubleJumpSound;
    public AudioSource dieSound;
    public AudioSource landeSound;
    public bool enableJump = true;
    public drinkBeer beerScript;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererEi;
    private float hue;
    private float sat;
    private float bri;
    private float timeAtJump = 0.0f;
    public float timeBetweenJumps = 0.5f;
    public lifeBar lBar;
    public ScenenManager sm;
    public levelVar lv;
    public GameObject enemyIdicator;
    public GameObject enemyIdicator_sb;
    public GameObject enemyIdicator_s;
    public float distandNotShowAnything = 200;
    private float distanceToBorder = 720;
    // private float rainbowSpeed = 0.1f;
    // private float rainbowTime = 0.0f;


    void Awake(){
      DontDestroyOnLoad(dieSound);
    } 
    // Start is called before the first frame update
    void Start()
    {

        my_Rigidbody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {
          score++;
        // make player fall down faster
        if (my_Rigidbody.velocity.y < 0)
        {
            my_Rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (1.0f - my_Rigidbody.velocity.y / 5.0f) * Time.deltaTime;
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
        if(!isGrounded){
            landeSound.Play();
                 isGrounded = true;
        }
        enableDoubleJump = false;
        if(hit.transform.gameObject.name == "schatzkarte"){
              switch (SceneManager.GetActiveScene().buildIndex)
              {
                  case 0:
                                SceneManager.LoadScene("SchatzkartenScene");
                  break;
                  case 1:
                                SceneManager.LoadScene("SchatzkartenScene2");
                  break;
                  case 2:
                                SceneManager.LoadScene("SchatzkartenScene3");
                  break;
                  case 3:
                                SceneManager.LoadScene("SchatzkartenScene4");
                  break;
                  case 4:
                                SceneManager.LoadScene("SchatzkartenScene5");
                  break;
                  
                  default:
                  break;
              }
        }
        else if(hit.transform.gameObject.name != "ground")
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

                    lv.currentLevel = SceneManager.GetActiveScene().buildIndex;
                    xPosS.xValue = transform.position.x;
                    SceneManager.LoadScene("EndScreen");
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

        if(lBar.currentLife <= 0){
            dieSound.Play();
       
            lv.currentLevel = SceneManager.GetActiveScene().buildIndex;
             xPosS.xValue = transform.position.x;
             SceneManager.LoadScene("EndScreen");  
        }

        if(transform.position.y < 20){
            dieSound.Play();
        
            lv.currentLevel = SceneManager.GetActiveScene().buildIndex;
            xPosS.xValue = transform.position.x;
             SceneManager.LoadScene("EndScreen");
        }

        TextFieldScore.text = "Score: " + ((int)(score/10)).ToString();
        scoreS.score = score;
        // increase speed of the player proportional to the score
        speedFactor = 200f + (score/300);
        //increase jump force proportional to the score
        // jumpForce = 25000.0f + (score/300);
        // GameObject g = findClosestEnemy();
           GameObject[] gs = findClosestEnemys();
            bool containsBlue = false;
            bool containsRed = false;
            bool containsGreen = false;
           foreach (GameObject o in gs){
               if(o != null){
                   if(o.tag == "skeleton" || o.tag == "barrel") containsBlue = true;
                   else if(o.tag == "soldier") containsRed = true;
                   else if(o.tag == "chest") containsGreen = true;
               }
           }
           if(containsBlue){
               enemyIdicator_sb.SetActive(true);
           }
           else{
               enemyIdicator_sb.SetActive(false);
           }
           if(containsRed){
               enemyIdicator_s.SetActive(true);
           }
           else{
               enemyIdicator_s.SetActive(false);
           }
           if(containsGreen){
               enemyIdicator.SetActive(true);
           }
           else{
               enemyIdicator.SetActive(false);
           }
    }

     GameObject[] findClosestEnemys(){
        object[] obj = GameObject.FindObjectsOfType(typeof (GameObject));
        GameObject[] closestObjs = new GameObject[obj.Length];
        int idx = 0;
                foreach (object o in obj)
                    {
                       GameObject g = (GameObject) o;
                       if(g.tag == "skeleton" || g.tag == "barrel" || g.tag == "chest" || g.tag == "soldier"){
                            float distanceG = g.gameObject.transform.position.x - (transform.position.x + distanceToBorder);
                            if(distanceG > 0){
                                if(distanceG < distandNotShowAnything){
                                    closestObjs[idx] = g;
                                    idx++;
                                }
                            }
                       }
                    
                }
        return closestObjs;
    }



    
}