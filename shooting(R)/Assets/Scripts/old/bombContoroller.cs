using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombContoroller : MonoBehaviour {

    int bst;
    float col_a = 0;
    float pvx, pvy,pang;
    float pspeed = playerController.Pspeed;
    //float pspeed = 0.3f;
    GameObject player;
    Vector3 pvd;
    
    // Use this for initialization
	void Start () {
        player = GameObject.Find ("player" );
        pspeed = playerController.Pspeed;

        

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

        switch (bst)
        {
            case 0:
                col_a += 0.2f;
                if (col_a >= 1) bst = 1;
                break;

            case 1:
                col_a -= 0.2f;
                if (col_a > 0)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col_a);
                }
                else Destroy(gameObject);
                break;
        }
    }

}
