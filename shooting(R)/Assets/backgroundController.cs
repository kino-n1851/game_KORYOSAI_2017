using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour
{

    GameObject player;
    float pspeed;
    //pspeed = playerController.Pspeed;
    Vector3 pvd;
    float pang, pvx, pvy;
    private float bgx, bgy;
    
    // Use this for initialization
    void Start()
        
    {
        Debug.Log(playerController.SceneCheck);
        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }
        pspeed = playerController.Pspeed;
        Debug.Log(pspeed);
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

            pvy = Mathf.Cos(pang * Mathf.Deg2Rad) *-pspeed;
            pvx = Mathf.Sin(pang * Mathf.Deg2Rad) *pspeed;

            pvd = new Vector3(pvx, pvy, 0);


            transform.position = transform.position + pvd;
        }

        bgx = transform.position.x;
        bgy = transform.position.y;
        //右スクロール時補充
        if (transform.position.x < -61.0f)
        {
            transform.position = new Vector3(61.0f, bgy, 0);
            
        }
        //左スクロール時補充
        if (transform.position.x > 61.0f)
        {
            transform.position = new Vector3(-61.0f, bgy, 0);
            
        }

        //上スクロール時補充
        if (transform.position.y < -38.7f)
        {
            transform.position = new Vector3(bgx, 38.7f, 0);
           
        }
        //下スクロール時補充
        if (transform.position.y > 38.7f)
        {
            transform.position = new Vector3(bgx, -38.7f, 0);
            
        }

    }

}
