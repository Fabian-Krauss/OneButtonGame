using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour
{
    public GameObject chest1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D hit)
        {

            if (hit.transform.gameObject == chest1)
            {
                Destroy(chest1);
            }

        if(hit.transform.gameObject.name == "ground")
        {
            Destroy(gameObject);
        }
    }
}
