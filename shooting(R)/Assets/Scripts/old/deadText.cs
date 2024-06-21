using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadText : MonoBehaviour {
    public Text mytext;
    float score;
    float ScoreX;
    int Sscore;
	// Use this for initialization
	void Start () {
       
        if (ChooseC.Difficulty == 0)
        {
            ScoreX = 1.0f;
        }
        else if (ChooseC.Difficulty == 1)
        {
            ScoreX = 2.0f;
        }
        else if (ChooseC.Difficulty == 2)
        {
            ScoreX = 3.5f;
        }
        score = score_boss.scoreb*ScoreX;
        Sscore = (int)score;
    }
	
	// Update is called once per frame
	void Update () {
        mytext.text = "Your Score "+ Sscore;
	}
}
