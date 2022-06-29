using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenenManager : MonoBehaviour
{
    public int sceneCounter = 0;
    public levelVar levelS;
    // Start is called before the first frame update
    void Start()
    {
        sceneCounter = (int) levelS.currentLevel;
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

    public void loadScene(int idx){
        sceneCounter = idx;
         SceneManager.LoadScene(idx);
    }

    public void loadNextScene(){
    //   levelS.currentLevel = sceneCounter;

      sceneCounter++;
      SceneManager.LoadScene(sceneCounter);
    }

    public void loadSceneAgain(){
    //   levelS.currentLevel = sceneCounter;
      Debug.Log("current scene: "+ sceneCounter);
      SceneManager.LoadScene(sceneCounter);
      sceneCounter++;
    }

    public void quit()
    {
        Debug.Log("On Quit");
        Application.Quit();
    }

    public void load1(){
        SceneManager.LoadScene(0);
    }

        public void load2(){
        SceneManager.LoadScene(1);
    }

        public void load3(){
        SceneManager.LoadScene(2);
    }

        public void load4(){
        SceneManager.LoadScene(3);
    }

        public void load5(){
        SceneManager.LoadScene(4);
    }
           public void loadMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
