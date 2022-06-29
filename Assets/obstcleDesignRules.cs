using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstcleDesignRules : MonoBehaviour
{

    public GameObject canon;
    public GameObject beer;
    public float protectedDistance = 500.0f;

    public float protectedDistanceChestSkel = 250.0f;

    public SkeletonFactory skeltFact;

    private int IS_CHEST = 0;
    private int IS_SKEL = 1;
    private int IS_BARREL = 2;
    private int IS_SOLDIER = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isPlaceOk(float position, int type){

         bool posIsOk = true;
         if(type == IS_CHEST){
            
         }
         else if(type == IS_SKEL){
               object[] obj = GameObject.FindObjectsOfType(typeof (GameObject));
                foreach (object o in obj)
                    {
                       GameObject g = (GameObject) o;
                       if(g.tag == "chest"){
        
                            if(Mathf.Abs(position - g.transform.position.x) < protectedDistanceChestSkel){
                                posIsOk = false; 
    
                            } 
                            
                       }
                }
                if(posIsOk) return true;
         }
         else if(type == IS_BARREL){

         }
         else if(type == IS_SOLDIER){

         }
         if(Mathf.Abs(position - canon.gameObject.transform.position.x) > protectedDistance  && Mathf.Abs(position - beer.gameObject.transform.position.x) > protectedDistance && posIsOk)  return true;
         return false;
    }
}
