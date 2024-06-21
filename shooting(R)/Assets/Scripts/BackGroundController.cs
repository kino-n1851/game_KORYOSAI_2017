using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataDefine;
public class BackGroundController : MonoBehaviour
{
    GameObject playerObject;
    PlayerTest playerScript;
    PlayerClass playerClass;
    float playerMoveSpeed = 0;
    float playerAngle;
    const float backGroundImageSize = 20f;
    Vector3 positionDelta;
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerScript = playerObject.GetComponent<PlayerTest>();
        playerScript.SpeedChangeHandler += SpeedChangeHandler;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerAngle = playerObject.transform.localEulerAngles.z;
        positionDelta = new Vector3(Mathf.Sin(playerAngle * Mathf.Deg2Rad) * playerMoveSpeed * Time.deltaTime,  Mathf.Cos(playerAngle * Mathf.Deg2Rad) * -playerMoveSpeed * Time.deltaTime, 0);

        transform.position = transform.position + positionDelta;

        //右スクロール時補充
        if (transform.position.x < -backGroundImageSize)
        {
            transform.position = new Vector3(backGroundImageSize, gameObject.transform.position.y, 0);
        }
        //左スクロール時補充
        if (transform.position.x > backGroundImageSize)
        {
            transform.position = new Vector3(-backGroundImageSize, gameObject.transform.position.y, 0);
        }

        //上スクロール時補充
        if (transform.position.y < -backGroundImageSize)
        {
            transform.position = new Vector3(gameObject.transform.position.x, backGroundImageSize, 0);
        }
        //下スクロール時補充
        if (transform.position.y > backGroundImageSize)
        {
            transform.position = new Vector3(gameObject.transform.position.x, -backGroundImageSize, 0);
        }

    }

    private void SpeedChangeHandler(float speed)
    {
        playerMoveSpeed = speed;
    }

}
