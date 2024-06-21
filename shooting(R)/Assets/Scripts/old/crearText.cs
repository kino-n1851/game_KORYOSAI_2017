using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class crearText : MonoBehaviour {

    int co;
    float score;
    int SScore;
    float ScoreX;
    public Text mytext;
    GameObject Player;
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
        SScore = (int)score;
        Player = GameObject.Find("player");
        mytext.text = "Game Clear!\nYourscore " + SScore;

        
    }
	
	// Update is called once per frame
	void Update () {

        if (Player == null)
        {
            Player = GameObject.Find("player");
        }
        co++;
        if (co > 120)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Player.GetComponent<playerController>().Reset();
                SceneManager.LoadScene("start scene_shooting");
            }
        }
	}
}
