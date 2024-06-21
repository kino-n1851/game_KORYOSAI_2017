using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecounter : MonoBehaviour {

   // int Gamect = 0;
    int co = 0;
    int Gametime;
    public static int score = 0;
    int scoret;
    int scorep;
    int scenest;
    GameObject SceneVS;
   
    public Text mytext;    // Use this for initialization
   
	void Start () {
        scenest = 0;
        DontDestroyOnLoad(this.gameObject);
        score = 0;
        
        SceneVS = GameObject.Find("changeDirector");
        mytext.text = "Start !!";
	}
	
	// Update is called once per frame
	void Update () {
        if (scenest == 0)
        {
            if (co < 130) { co++; }
            else if (playerController.PLst != 1)
            {
                score = (scoret / 3) + scorep;
                mytext.text = "Score " + score;

                scoret++;
                Gametime++;
            }


            //Gamect++;

            if (Gametime >= 3000)
            {
                // Gamect = 0; 
                score = 1000 + scorep;
                Debug.Log(scorep);
                scenest = 1;
                SceneVS.GetComponent<VSsceneDirector>().VSsceneChange();

            }
        }
        
 	}

    public void pointGet(int point)
    {
        scorep += point;
    }
    public void DestroyS()
    {
        Destroy(gameObject);
    }
}
