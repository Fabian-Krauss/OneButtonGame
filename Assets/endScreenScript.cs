using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreenScript : MonoBehaviour
{

     public ScoreScript scoreS;
     public Text TextFieldScore;

     public xPosScript xPosS;
     public Text TextFieldXpos;

     public float levelLength = 22000.0f;

     public levelVar levelS;

    // Start is called before the first frame update
    void Start()
    {
        TextFieldScore.text = "Score: " + ((int)(scoreS.score/10)).ToString();
        TextFieldXpos.text = "Level was " + ((int)(((xPosS.xValue)/levelLength)*100)).ToString() + " % completed!";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
