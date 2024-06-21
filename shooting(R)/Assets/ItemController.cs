using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    int ItemCount;
    GameObject player;
    float pang, pvx, pvy, pspeed;
    Vector3 pvd;
    private float col_a = 1;
    SpriteRenderer spRenderer;
    int count;
    // Use this for initialization
    void Start()
    {
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        pspeed = playerController.Pspeed;
        spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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



        if (count > 200)
        {
            if (col_a > 0)
            {

                col_a -= 0.01f;
                var colorI = spRenderer.color;
                colorI.a = col_a;
                spRenderer.color = colorI;


            }
            else Destroy(gameObject);
        }
        else count++;

        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            Destroy(gameObject);
        }
           
    }
}
