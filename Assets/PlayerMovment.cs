using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{

    public Rigidbody my_Rigidbody;
    public Text TextFieldScore;
    public Vector3 jump;
    public float speedFactor = 6f;
    public Vector3 speed = new Vector3(1, 0, 0);
    public float jumpForce = 20.0f;
    public bool isGrounded;
    public float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        my_Rigidbody.MovePosition(transform.position + speed*Time.deltaTime*speedFactor);
        // if (Input.GetKey("left") || Input.GetKey("right"))
        // {
        //     Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //     my_Rigidbody.MovePosition(transform.position + my_Input*Time.deltaTime*5f);
        // }
    }

    // void OnCollisionEnter (Collider target)
    // {
    //  isGrounded = true;
    //   if(target.gameObject.tag.Equals("barrel_open_rolling") == true )
    //   {
    //        Debug.Log("Collide");
    //   }
    // }
    // void OnCollisionEnter ()
    // {
    //  isGrounded = true;
    // }

    void OnCollisionEnter (Collision hit)
    {
        isGrounded = true;
        if(hit.transform.gameObject.name == "barrel")
        {
            Debug.Log("Collide");
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

            my_Rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
            score++;
            TextFieldScore.text = score.ToString();
    }
}
