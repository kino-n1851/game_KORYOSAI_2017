using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mis1Controller : MonoBehaviour {

    Vector3 pvd;
    GameObject player;
    GameObject flare0;
    GameObject flare1;
    GameObject flare2;
    GameObject flare3;
    GameObject flare4;
    GameObject flare5;
    GameObject efectgene;
    GameObject Item;

    int fct,fno;
    float pspeed;
    float pang;
    float eang,exa,eya,ex,ey,eva;
    float Dexa, Deya;
    float time = 500;
    float Tang;
    float count,lco;
    float pvx, pvy;
    private float espeed = 0.3f;//0.1f;
    int serchco;
    
    // Use this for initialization
    void Start () {
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        efectgene = GameObject.Find("efectGenerater");
        Item = GameObject.Find("ItemGenerater");

        pspeed = playerController.Pspeed;

        eang = transform.localEulerAngles.z;
        exa = transform.position.x;
        eya = transform.position.y * -1;

        Tang = Mathf.Atan2(exa, eya) * Mathf.Rad2Deg;
        if (Tang < 0)
        {
            Tang += 360;
        }

        transform.rotation = Quaternion.Euler(0,0,Tang);
        
    }
	
	// Update is called once per frame
	void Update () {

        //normal

        if (player == null)
        {
            player = GameObject.Find("player");
        }
        if (playerController.PLst == 0)
        {


            eang = transform.localEulerAngles.z;
            exa = transform.position.x;
            eya = transform.position.y * -1;

            Tang = Mathf.Atan2(exa, eya) * Mathf.Rad2Deg;
            if (Tang < 0)
            {
                Tang += 360;
            }
            //this.transform.rotation = Quaternion.Euler(0, 0, rad);
            eva = Mathf.DeltaAngle(eang, Tang);
            if (Mathf.Abs(eva) < 3)
            {
                if (espeed < pspeed + (pspeed / 9.5f)) espeed += 0.003f;
            }
            else if (eva > 0)
            {
                transform.Rotate(0, 0, 2.3f);
              //  if (espeed > pspeed - (pspeed / 15.0f)) espeed -= 0.002f;
            }
            else
            {
                transform.Rotate(0, 0, -2.3f);
               // if (espeed > pspeed - (pspeed / 15.0f)) espeed -= 0.002f;
            }
        }
        //flare
        
        if (playerController.PLst == 2)
        {
            

            eang = transform.localEulerAngles.z;
            exa = transform.position.x;
            eya = transform.position.y * -1;
            serchco++;
            if (serchco > 30)
            {
                for (fct = 0; fct > 6; fct++)
                {
                    fno = Random.Range(0, 6);

                }
            }

             switch (fno)
             {
                 case 0:
                     Dexa = GameObject.Find("Flare0").transform.position.x - exa;
                     Deya = GameObject.Find("Flare0").transform.position.y - eya;
                     break;

                 case 1:
                     Dexa = GameObject.Find("Flare1").transform.position.x - exa;
                     Deya = GameObject.Find("Flare1").transform.position.y - eya;
                     break;

                 case 2:
                     Dexa = GameObject.Find("Flare2").transform.position.x - exa;
                     Deya = GameObject.Find("Flare2").transform.position.y - eya;
                    break;

                 case 3:
                    Dexa = GameObject.Find("Flare3").transform.position.x - exa;
                    Deya = GameObject.Find("Flare3").transform.position.y - eya;
                    break;

                 case 4:
                    Dexa = GameObject.Find("Flare4").transform.position.x - exa;
                    Deya = GameObject.Find("Flare4").transform.position.y - eya;
                    break;

                 default:
                    Dexa = GameObject.Find("Flare5").transform.position.x - exa;
                    Deya = GameObject.Find("Flare5").transform.position.y - eya;
                    break;



             }
            

           
           

            
           

            Tang = Mathf.Atan2(-Deya,Dexa) * Mathf.Rad2Deg;
            if (Tang < 0)
            {
                Tang += 360;
            }
            
           
            //this.transform.rotation = Quaternion.Euler(0, 0, rad);
            eva = Mathf.DeltaAngle(eang, Tang);
            if (Mathf.Abs(eva) < 3)
            {
                if (espeed < pspeed + (pspeed / 9.5f)) espeed += 0.003f;
             
            }
            else if (eva > 0)
            {
                //transform.Rotate(0, 0, 2.3f);
                transform.Rotate(0, 0, 2.6f);
                if (espeed > pspeed - (pspeed / 15.0f)) espeed -= 0.002f;
            }
            else
            {
                transform.Rotate(0, 0, -2.6f);
                if (espeed > pspeed - (pspeed / 15.0f)) espeed -= 0.002f;

            }
            
        }

        if (playerController.PLst != 1)
        { 
            pang = this.player.transform.localEulerAngles.z;

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;

            
        }
        
        
        transform.Translate(0,espeed,0);

        time -= 1;
       
        if (time < 0) { Destroy(gameObject); }

        lco += 1;
        if (lco > 3)
        {
            lco = 0;
            
            efectgene.GetComponent<efectGenerater>().lineGene(transform.position.x, transform.position.y, 0.8f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy1")
        {
            Item.GetComponent<itemGenerater>().Hitcheck(transform.position.x,transform.position.y);
        }


        Destroy(gameObject);

        
        
        efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y,1);
    }

}
