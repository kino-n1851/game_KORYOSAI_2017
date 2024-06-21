using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathDirector : MonoBehaviour {

	int waitct = 0;
    GameObject player;
    
    // Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		
        if (playerController.PLst == 1)
        {
            if (waitct < 120)
            {
                waitct++;
            }
            else
            {
                waitct = 0;
               
               
                SceneManager.LoadScene("death scene_shooting");
            }
        }
	}
}
