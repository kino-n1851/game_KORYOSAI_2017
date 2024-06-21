using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZANKIcontroller : MonoBehaviour {

    private int ZANKI;
    public int Fpoint;
    public Text ZANKItext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Fpoint = playerController.Fpoint;
            ZANKI = playerController.plZANKI;
        ZANKItext.text = "Your Life " + ZANKI+"\n    Flare "+Fpoint;
        
	}
}
