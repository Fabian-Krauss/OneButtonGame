using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{

    public Rigidbody2D my_Rigidbody;

    public Text TextFieldScore;
    public float speedFactor = 2000f;
    public float jumpForce = 200.0f;
    public Vector2 jump;
    public bool isGrounded = true;
    public float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        my_Rigidbody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        my_Rigidbody.velocity = new Vector2(speedFactor,my_Rigidbody.velocity.y);
        if (Input.GetKey("space")&& isGrounded)
        {   
            // my_Rigidbody.velocity = new Vector2(my_Rigidbody.velocity.x, jumpForce);
            my_Rigidbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
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
        if(hit.transform.gameObject.name == "obst_chest")
        {
            Debug.Log("Collide");
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

        //     my_Rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
        //     isGrounded = false;
        // }
        // Debug.Log("Test");
        score++;
        TextFieldScore.text = "Score: " + ((int)(score/10)).ToString();
    }
}
