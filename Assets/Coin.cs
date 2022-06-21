using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{

    public GameObject coin;
    public PlayerMovment Player;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void OnTriggerEnter(){
    //     Debug.Log("Collide Coin");
    //     Destroy(coin);
    // }

    // void FixedUpdate(){
    //     Vector2 pos = transform.position;

    //     pos.x -= Player.speedFactor.x * Time.deltaTime;
    //     if (pos.x < -100)
    //     {
    //         Destroy(coin);
    //         Debug.Log("Destroy Coin");
    //     }
    // }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Collide Coin");
            Destroy(coin);
            Player.score += 1000;
        }
    }
}
