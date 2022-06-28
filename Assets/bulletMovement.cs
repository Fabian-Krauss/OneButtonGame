using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public Rigidbody2D my_Rigidbody;
    public float speedFactor = 200f;
    // Start is called before the first frame update
    void Start()
    {
       my_Rigidbody.velocity = new Vector2(-speedFactor,my_Rigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
         my_Rigidbody.velocity = new Vector2(-speedFactor,my_Rigidbody.velocity.y);
    }

        void OnCollisionEnter2D(Collision2D hit){

         Physics2D.IgnoreCollision(hit.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }
}
