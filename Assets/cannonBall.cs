using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour
{
    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;

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

            if (hit.transform.gameObject == chest1 || hit.transform.gameObject == chest2 || hit.transform.gameObject == chest3)
            {
                Destroy(chest1);
                Destroy(chest2);
                Destroy(chest3);
            }

        if(hit.transform.gameObject.name == "ground")
        {
            Destroy(gameObject);
        }
    }
}
