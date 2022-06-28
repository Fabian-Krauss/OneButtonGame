using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierMovement : MonoBehaviour
{
    public Rigidbody2D my_Rigidbody;
    public float speedFactor = 200f;
    public float time = 0.0f;
    public float minShootTime = 3.0f;
    public float maxShootTime = 5.0f;
    public float shootTime = 0.0f;
    public GameObject bullet;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
         shootTime = Random.Range(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
              my_Rigidbody.velocity = new Vector2(-speedFactor,my_Rigidbody.velocity.y);
              time+=Time.deltaTime;
              if(time > shootTime){
                  time = 0.0f;
                  GameObject bulletClone = Instantiate(bullet, gun.gameObject.transform.position, gun.gameObject.transform.rotation);
                  shootTime = Random.Range(minShootTime, maxShootTime);
              }
    }

    void OnCollisionEnter2D(Collision2D hit){
        if(hit.transform.gameObject.name != "ground")
        {
                 Debug.Log("i found collision with" + hit.transform.gameObject.name);
                 Physics2D.IgnoreCollision(hit.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
