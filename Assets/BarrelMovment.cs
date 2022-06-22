using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovment : MonoBehaviour
{
    public Rigidbody2D my_Rigidbody;
    public float speedFactor = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // roll the barrel to the left
        my_Rigidbody.velocity = new Vector2(-speedFactor, my_Rigidbody.velocity.y);

    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.gameObject.tag == "chest")
        {
            Debug.Log("Collide Barrel with Chest");
            Physics2D.IgnoreCollision(hit.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
}
