using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour {

    GameObject player;
    float pang, pvy, pvx, pspeed;
    Vector3 pvd;

    int ct;
    float sx = 0.1f, sy = 0.1f;
	// Use this for initialization
	void Start () {
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        pspeed = playerController.Pspeed;
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
	}
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
            player = GameObject.Find("player");
        }

        if (sx < 0.5f) sx = sx + 0.01f;
        if (sy < 25) sy = sy + 0.7f;
        this.transform.localScale = new Vector3 (sx,sy,1);

        ct++;
        if (ct >= 45)
        {
            Destroy(gameObject);
        }


        if (playerController.PLst != 1)
        {
            pang = this.player.transform.localEulerAngles.z;

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;
        }
    }
}
