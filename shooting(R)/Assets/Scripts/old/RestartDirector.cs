using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartDirector : MonoBehaviour {

    GameObject Player;
    GameObject scorer;
    int waitc = 0;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("player");
        scorer = GameObject.Find("score");
        { //reset




           
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Player == null)
        {
            Player = GameObject.Find("player");
        }
        if (waitc < 30)
        {
            waitc++;
        }else if (Input.GetKeyDown(KeyCode.S))
        {


            Player.GetComponent<playerController>().Reset();

            waitc = 0;
            
           // scorer.GetComponent<scorecounter>().DestroyS();
            SceneManager.LoadScene("start scene_shooting");
        }
	}
}
