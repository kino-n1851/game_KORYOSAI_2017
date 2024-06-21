using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardChC : MonoBehaviour {

   public Text mytext;
    
	// Use this for initialization
	void Start () {
        mytext.text = "Hard";
	}
	
	// Update is called once per frame
	void Update () {
		
        if (ChooseC.Difficulty == 1)
        {
            mytext.text = "Hard";
        }
        else if(ChooseC.Difficulty == 2)
        {

            mytext.text = "Lunatic";

        }
                
        else if(ChooseC.Difficulty == 0){

            mytext.text = " ";

        }

	}
}
