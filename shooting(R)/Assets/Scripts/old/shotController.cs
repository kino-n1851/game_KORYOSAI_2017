using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotController : MonoBehaviour {

    GameObject efectgene;
    GameObject player;
    float pang, pvy, pvx, pspeed;
    Vector3 pvd;
    int co;
    int shotco;
	// Use this for initialization
	void Start () {

        efectgene = GameObject.Find("efectGenerater");
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        pspeed = playerController.Pspeed;
    }

    // Update is called once per frame
    void Update () {

        if (player == null)
        {
            player = GameObject.Find("player");
        }

        transform.Translate(0, 0.8f, 0);



        co++;
        shotco++;

        if (playerController.PLst != 1)
        {
            pang = this.player.transform.localEulerAngles.z;

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;
        }

        if (shotco > 6)
        {

            efectgene.GetComponent<efectGenerater>().lineGene(transform.position.x, transform.position.y,0.6f);
            shotco = 0;
        }


        
        

        if (co > 180)
        {
            Destroy(gameObject);
            efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y,0.6f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy" || other.tag == "Senemy")
        {

            efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y,0.6f);
            Destroy(gameObject);

        }
    }
}
