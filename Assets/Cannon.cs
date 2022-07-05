using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject bar;
    public GameObject player;
    public PlayerMovment playerMovment;
    public progressBar barScript;
    public GameObject cannonBall;
    public bool hasShot = false;
    public float shootSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        // chek if player is near the cannon
        if (Mathf.Abs(player.gameObject.transform.position.x - transform.position.x) < 450 && transform.position.x > player.gameObject.transform.position.x)
        {
            playerMovment.enableJump = false;
            Debug.Log("Player is near the cannon");
            bar.gameObject.SetActive(true);
            playerMovment.isNearCanon = true;
        }else{
            bar.gameObject.SetActive(false);
            playerMovment.enableJump = true;
            playerMovment.isNearCanon = false;
        }
        if (barScript.slider.value == 1)
        {
            if ((Input.GetKeyUp(KeyCode.Space) || transform.position.x > player.gameObject.transform.position.x) && !hasShot){
                hasShot = true;
                GameObject cannonBallClone = Instantiate(cannonBall, transform.position, transform.rotation);
                cannonBallClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, 0) * shootSpeed);
            }
        }
    }
}
