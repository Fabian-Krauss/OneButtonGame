using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class schatzkartenSceneSkript : MonoBehaviour
{
    public Text TextFieldScore;
    public ScoreScript scoreS;
    // Start is called before the first frame update
    void Start()
    {
        TextFieldScore.text = "Score: " + ((int)(scoreS.score/10)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
