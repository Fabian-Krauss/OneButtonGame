using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{
    public Slider slider;
    public float targetHoldTime = 0.6f;
    public float holdTime = 0.0f;
    // Start is called before the first frame update

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // increase the progress bar during space press
        if (Input.GetKey(KeyCode.Space))
        {
            holdTime += Time.deltaTime;
            if (holdTime >= targetHoldTime)
            {
                holdTime = targetHoldTime;
            }
            slider.value = holdTime / targetHoldTime;
        }

        // reset the progress bar when space is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            holdTime = 0.0f;
            slider.value = 0.0f;
        }
        
    }
}
