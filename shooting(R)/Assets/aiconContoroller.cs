using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiconContoroller : MonoBehaviour {

    float pang, pvy, pvx, pspeed;
    GameObject player;
    Vector3 pvd;
    int ct;
	// Use this for initialization
	void Start () {
        player = GameObject.Find ( "player" );
        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.7f);
	}
	
	// Update is called once per frame
	void Update () {


        if (playerController.PLst != 1)
        {
            pang = this.player.transform.localEulerAngles.z;

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

           

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;
        }



        ct++;

        if (ct > 75)
        {
            Destroy(gameObject);
        }
	}
}
