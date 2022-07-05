using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkBeer : MonoBehaviour
{
    public GameObject bar;
    public GameObject player;
    public PlayerMovment playerMovment;
    public progressBarBeer barScript;
    public bool hasBeenDrunken = false;
    public bool positionOk = false;
    public bool zerfickerModus = false;
    public float zerfickerActiveTime = 3.0f;
    public float zerfickerTime= 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        bar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (Mathf.Abs(player.gameObject.transform.position.x - transform.position.x) < 450 && transform.position.x > player.gameObject.transform.position.x)
        {
            if(!positionOk){
                playerMovment.enableJump = false;
                Debug.Log("Player is near the beer");
                bar.gameObject.SetActive(true);
                positionOk = true;
            }
        }else{
            if(!zerfickerModus) bar.gameObject.SetActive(false);
            playerMovment.enableJump = true;
            positionOk = false;
        }
        if (barScript.slider.value == 1)
        {
            if ((Input.GetKeyUp(KeyCode.Space) || transform.position.x > player.gameObject.transform.position.x) && !hasBeenDrunken){
                hasBeenDrunken = true;
                zerfickerModus = true;
                Debug.Log("Bier ist gsoffen");
            }
        }
        if(zerfickerModus){
            zerfickerTime+=Time.deltaTime;
            barScript.slider.value = 1- zerfickerTime/zerfickerActiveTime;
            if(zerfickerTime > zerfickerActiveTime){
                zerfickerModus = false;
                bar.gameObject.SetActive(false);
            }
        }
    }
}
