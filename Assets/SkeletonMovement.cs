using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public GameObject Skeleton;
    public Rigidbody2D my_Rigidbody;
    public float changeDirectionTime = 1.0f;
    public float changeDirectionTimeLow = 2.0f;
    public float changeDirectionTimeHigh = 3.0f;
    public float time = 0.0f;
    public float speedFactor = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        my_Rigidbody = GetComponent<Rigidbody2D>();
        my_Rigidbody.velocity = new Vector2(speedFactor,my_Rigidbody.velocity.y);
    }

     void FixedUpdate()
    {       
        time += Time.deltaTime;
        if(time >= changeDirectionTime)
        {
            time = 0.0f;
            if ( my_Rigidbody.velocity.x != 0){
            my_Rigidbody.velocity = new Vector2(-my_Rigidbody.velocity.x/Mathf.Abs(my_Rigidbody.velocity.x)*speedFactor, my_Rigidbody.velocity.y);
            // Debug.Log("Change Direction " + my_Rigidbody.name + " velocity: " + my_Rigidbody.velocity);
            changeDirectionTime = Random.Range(changeDirectionTimeLow, changeDirectionTimeHigh);
        }
        }
    }

        void OnCollisionEnter2D(Collision2D hit)
        {
        if(hit.transform.gameObject.name != "ground" && hit.transform.gameObject.name != "Player")
        {
            my_Rigidbody.velocity = new Vector2(-my_Rigidbody.velocity.x/Mathf.Abs(my_Rigidbody.velocity.x)*speedFactor, my_Rigidbody.velocity.y);
            // Physics2D.IgnoreCollision(hit.collider, GetComponent<Collider2D>());
        }
        if(hit.transform.gameObject.tag == "barrel"){
            Destroy(Skeleton);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}


