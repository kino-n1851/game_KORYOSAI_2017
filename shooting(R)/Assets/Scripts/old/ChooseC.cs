using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseC : MonoBehaviour {


    public static int Difficulty;
    int Lunact;
    float time;
   public Text mytext;
    GameObject player;

	// Use this for initialization
	void Start () {
        Difficulty = 0;
        mytext.text = "Easy";
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        
        if (player == null)
        {
            player = GameObject.Find("player");
        
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Difficulty == 0)
            {
                player.GetComponent<playerController>().ZANKI(15);
            }else if(Difficulty == 1)
            {
                player.GetComponent<playerController>().ZANKI(10);
            }
            else
            {
                player.GetComponent<playerController>().ZANKI(7);
            }

            player.GetComponent<playerController>().startFl(true);

            SceneManager.LoadScene("shooting()");
        }
        else
        { 
            time += Time.deltaTime;
            if ((time > 0.3f) && Lunact > 0)
            {
                Lunact--;
                time = 0;
            }
            if (Difficulty == 0)
            {
                mytext.text = "Easy";
            }
            else
            {
                mytext.text = " ";
            }



            if (Input.GetKeyDown(KeyCode.A) && Difficulty != 0)
            {
                Difficulty = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D) && Difficulty != 2)
            {
                Difficulty = 1;
                Lunact++;

            }
            if (Lunact > 6)
            {
                Debug.Log("Luna");
                Difficulty = 2;
            }



        }
        
            
       
	}
}
