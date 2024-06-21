                                                                                                           using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attentionController : MonoBehaviour {


    int co;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update(){
        co++;
        if (co > 60)
        {
            Destroy(gameObject);
        }
            }

}

