using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flareController : MonoBehaviour {

    private float fspeed;
    private float fsA =0.002f;
    float pvx, pvy, pang;
    float pspeed = 0.30f;//playerController.Pspeed;
    float col_a = 1.0f;
  
    //float pspeed = 0.0f;
    GameObject player;
    Vector3 pvd;

	// Use this for initialization
	void Start () {

        //pspeed = playerController.Pspeed;
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        pang = player.transform.localEulerAngles.z;
        this.transform.rotation = Quaternion.Euler(0, 0, pang + Random.Range(-90.0f,91.0f));
        fspeed = Random.Range(0.1f,0.3f);
        pspeed = playerController.Pspeed;
    }
	
	// Update is called once per frame
	void Update () {

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0,0,0);
            fspeed = 0.1f;
            fsA = 0.005f;
            this.transform.rotation = Quaternion.Euler(0, 0, pang);
            Debug.Log(transform.rotation.z);  
        }*/

        if (fspeed > 0.05f)
        {
            fsA += 0.0005f;
            fspeed -= fsA;
            transform.Translate(0, -fspeed, 0);
        }
        
        else
        {
            if (col_a > 0)
            {
                col_a -= 0.02f;
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col_a);
            }
            else Destroy(gameObject);
            
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
