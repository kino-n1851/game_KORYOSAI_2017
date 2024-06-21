using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mis3Controller : MonoBehaviour
{

    GameObject player;
    Vector3 pvd;
    GameObject efectgene;
    float pspeed = playerController.Pspeed;
    //float pspeed = 0.3f;
    float exa, eya, time;
    float pang, pvy, pvx;
    private int Lco;
    // Use this for initialization
    void Start()
    {
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        efectgene = GameObject.Find("efectGenerater");

        pspeed = playerController.Pspeed;
        


       
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.PLst != 1)
        {
            pang = this.player.transform.localEulerAngles.z;

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;
        }


      
        //transform.Translate(0,0.4f,0);
        transform.Translate(0, 0.65f, 0);

        time += 1;
        if (time > 300) Destroy(gameObject);


        if (Lco > 6)
        {
            Lco = 0;
            
            efectgene.GetComponent<efectGenerater>().lineGene(transform.position.x, transform.position.y,0.8f);
        }
    }

}
