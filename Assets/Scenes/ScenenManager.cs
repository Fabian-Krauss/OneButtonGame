using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        Debug.Log("On Change");
        SceneManager.LoadScene("PiratesMainScene");
    }

    public void quit()
    {
        Debug.Log("On Quit");
        Application.Quit();
    }
}
