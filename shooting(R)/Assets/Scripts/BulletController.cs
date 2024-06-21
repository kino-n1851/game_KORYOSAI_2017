using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataDefine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private float bulletDuration = 2.0f;
    private float bulletSpeed = 0.0f;
    private float passedTime = 0;
    float playerMoveSpeed = 0;
    float playerAngle;
    Vector3 positionDelta;
    private GameObject playerObject;
    PlayerClass playerClass;
    void Start()
    {
        //SetShotSpeed(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        passedTime += Time.deltaTime;
        if(passedTime > bulletDuration)
        {
            Destroy(this.gameObject);
            return;
        }
        playerAngle = playerObject.transform.localEulerAngles.z;
        positionDelta = new Vector3(Mathf.Sin(playerAngle * Mathf.Deg2Rad) * playerMoveSpeed * Time.deltaTime,  Mathf.Cos(playerAngle * Mathf.Deg2Rad) * -playerMoveSpeed * Time.deltaTime, 0);

        transform.localPosition = transform.position + positionDelta + transform.up*bulletSpeed*Time.deltaTime;
    }

    public void SetShotSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    public void SetPlayerObject(GameObject _playerObject)
    {
        playerObject = _playerObject;
        playerObject.GetComponent<PlayerTest>().SpeedChangeHandler += SpeedChangeHandler;
    }

    public void SetPlayerClass(PlayerClass _playerClass)
    {
        playerClass = _playerClass;
        playerMoveSpeed = playerClass.getMoveSpeed();
    }
    private void SpeedChangeHandler(float speed)
    {
        playerMoveSpeed = speed;
    }
}
