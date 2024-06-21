using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitDirect : MonoBehaviour {

    int countQ;
    float TIme;

 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.W))
        {
            countQ++;
        }
        TIme += Time.deltaTime;
        if (TIme > 0.3f)
        {
            TIme = 0;
            countQ--;
        }

        if (countQ > 4)
        {
            Debug.Log("Quit");
            Application.Quit();
        }

	}
}
