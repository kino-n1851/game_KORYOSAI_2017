using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VSsceneDirector : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void VSsceneChange()
    {
        if (playerController.PLst != 1)
        {
            player.GetComponent<playerController>().ScenecheckP1(2);
            SceneManager.LoadScene("boss scene_shooting");
        }
    }
}
