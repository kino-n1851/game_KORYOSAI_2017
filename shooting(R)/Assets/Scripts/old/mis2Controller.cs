using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mis2Controller : MonoBehaviour {

    GameObject player;
    GameObject LaserGe;
    Vector3 pvd;
    float pspeed = playerController.Pspeed;
    //float pspeed = 0.3f;
    float  exa, eya, rad,time;
    float pang, pvy, pvx;
    GameObject efectgene;
    private int co; 

    // Use this for initialization
    void Start () {
        LaserGe = GameObject.Find("efectGenerater");
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        pspeed = playerController.Pspeed;
        //eang = transform.localEulerAngles.z;
        exa = transform.position.x;
        eya = transform.position.y * -1;
        
        efectgene =  GameObject.Find("efectGenerater");

        rad = Mathf.Atan2(exa, eya) * Mathf.Rad2Deg;
        if (rad < 0)
        {
            rad += 360;
        }

        
        LaserGe.GetComponent<efectGenerater>().laserGene(transform.position.x,transform.position.y, rad);
    }

    // Update is called once per frame
    void Update() {

        if (player == null)
        {
            player = GameObject.Find("player");
        }

        if (playerController.PLst != 1) 
        { pang = this.player.transform.localEulerAngles.z;

        pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
        pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

        pvd = new Vector3(pvx, pvy, 0);


        transform.position = transform.position + pvd; }


        transform.rotation = Quaternion.Euler(0,0,rad);
        //transform.Translate(0,0.4f,0);
        transform.Translate(0, 0.65f, 0);

        time += 1;
        if (time > 300) Destroy(gameObject);

        co++;
        if (co>3)
        {

            co = 0;
            efectgene.GetComponent<efectGenerater>().lineGene(transform.position.x, transform.position.y,1);
        }
    }

}
