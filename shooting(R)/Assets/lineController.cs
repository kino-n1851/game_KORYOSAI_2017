using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineController : MonoBehaviour {

    int lst = 0;
    float col_a = 0.0f;
    float sca = 0.05f;
    float pang, pvx, pvy;
    float pspeed = playerController.Pspeed;
    //float pspeed = 0.30f;//0.0f;//0.15f;
    Vector3 pvd;
    GameObject player;
    
    // Use this for initialization
    void Start () {
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }

        //

    }

    // Update is called once per frame
    void Update() {

        if (player == null)
        {
            player = GameObject.Find("player");
        }

        if (playerController.PLst != 1)
        {
            pang = this.player.transform.localEulerAngles.z;

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;
        }

        switch (lst)
        {
            case 0:
                col_a += 0.1f;
                if (col_a >= 1) lst = 1;
                if (sca < 0.25f) sca += 0.015f;
                
                break;

            case 1:

                sca = 0.25f;
            col_a -= 0.02f;
            if (col_a > 0)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col_a);
            }
            else Destroy(gameObject);
                break;

        }

        this.transform.localScale = new Vector3(sca, sca, 1);
    }
}
