using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenenManager : MonoBehaviour
{

    public int sceneCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        // load PiratesMainScene on space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // SceneManager.LoadScene("PiratesMainScene");
        }
        
    }

    public void changeScene()
    {
        Debug.Log("On Change");
        SceneManager.LoadScene("PiratesMainScene");
    }

    public void loadNextScene(){
      sceneCounter++;
      switch (sceneCounter)
      {
          case 1:
             SceneManager.LoadScene("Level2");
          break;
          case 2:
              SceneManager.LoadScene("Level3");
          break;
          case 3:
              SceneManager.LoadScene("Level4");
          break;
          case 4:
              SceneManager.LoadScene("Level5");
          break;
           case 5:
              SceneManager.LoadScene("Level5");
          break;

          default:
          break;
      }
    }

    public void quit()
    {
        Debug.Log("On Quit");
        Application.Quit();
    }
}
