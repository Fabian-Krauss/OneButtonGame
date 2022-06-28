using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemon : MonoBehaviour
{    
    
    public GameObject Lemon;
    public PlayerMovment Player;
    public lifeBar lifeBar;
    // public AudioSource lemonSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

         void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            // Debug.Log("Collide Lemon");
            if(lifeBar.currentLife <= 0.75f){
                lifeBar.lifeGained += 0.25f;
            }
            else{
                lifeBar.lifeGained += 1-lifeBar.currentLife;
            }
            Destroy(Lemon);
            
            // lemonSound.Play();
        }
    }
}
