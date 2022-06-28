using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeBar : MonoBehaviour
{
    public Slider slider;
    public float startLife = 1.0f;
    public float currentLife = 1.0f;
    public float timeToLifeWithoutLemon = 20.0f;
    public float lifeGained = 1.0f;
    public float time = 0.0f;
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

       time += Time.deltaTime;
       currentLife = lifeGained - time/timeToLifeWithoutLemon;
       slider.value = currentLife;
        
    }
}
