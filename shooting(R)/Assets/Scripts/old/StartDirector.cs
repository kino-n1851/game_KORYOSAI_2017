using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector: MonoBehaviour {

    GameObject Player;
    int waitc = 0;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        if (waitc < 60)
        {
            waitc++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            waitc = 0; 
          
            SceneManager.LoadScene("Choose");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            
            Application.Quit();
        }
	}
}
