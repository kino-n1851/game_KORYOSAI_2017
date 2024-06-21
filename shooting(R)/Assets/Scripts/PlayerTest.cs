using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataDefine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject BulletsFolder;
    private PlayerClass myPlayerClass;
    private PlayerClass.PlayerState playerState;
    public delegate void OnSpeedChangeDelegate(float speed);
    public OnSpeedChangeDelegate SpeedChangeHandler;
    private Transform muzzleTransform;
    private Transform bulletsFolderTransform;
    private float playerScale = 0.4f;
    private float color_a = 1.0f;
    private float angleClearance = 2.0f;
    private float contractionRate = 0.7f;
    private float shotCoolTime = 0.1f;
    private float shotPassedTime = 0;
    private enum angleName{
        UPPER=0,
        LEFT_UPPER = 45,
        LEFT = 90,
        LEFT_LOWER = 135,
        LOWER = 180,
        RIGHT_LOWER = 225,
        RIGHT = 270,
        RIGHT_UPPER = 315,
        UPPER2 = 360,
    }
    void Start()
    {
        int life = 5;
        int flare = 5;
        float speed = 10.0f;
        float angleVelocity = 5.0f;
        playerScale = this.gameObject.transform.localScale.x;
        muzzleTransform = this.gameObject.transform.Find("muzzle");
        bulletsFolderTransform = BulletsFolder.transform;

        myPlayerClass = new PlayerClass(life, flare, speed, angleVelocity);
        changeMoveSpeed(speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        CheckKeyInput();
    }

    void CheckKeyInput(){
        float currentAngle = this.gameObject.transform.localEulerAngles.z;
        if (Input.GetKey((KeyCode)KeyAssign.UPPER) & Input.GetKey((KeyCode)KeyAssign.RIGHT))
        {
            if (currentAngle > (int)angleName.RIGHT_UPPER + angleClearance || currentAngle < (int)angleName.RIGHT_UPPER - angleClearance)
            {
                //回転方向の決定
                if (currentAngle <= (int)angleName.LEFT_LOWER || currentAngle > (int)angleName.RIGHT_UPPER + angleClearance)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
                if (currentAngle < (int)angleName.RIGHT_UPPER - angleClearance && currentAngle > (int)angleName.LEFT_LOWER)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        else if (Input.GetKey((KeyCode)KeyAssign.LOWER) && Input.GetKey((KeyCode)KeyAssign.RIGHT))
        {
            if (currentAngle > (int)angleName.RIGHT_LOWER + angleClearance || currentAngle < (int)angleName.RIGHT_LOWER - angleClearance)
            {
                if (currentAngle <= (int)angleName.LEFT_UPPER || currentAngle > (int)angleName.RIGHT_LOWER + angleClearance)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
                if (currentAngle < (int)angleName.RIGHT_LOWER - angleClearance & currentAngle > (int)angleName.LEFT_UPPER)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        else if (Input.GetKey((KeyCode)KeyAssign.LOWER) & Input.GetKey((KeyCode)KeyAssign.LEFT))
        {
            if (currentAngle > (int)angleName.LEFT_LOWER + angleClearance || currentAngle < (int)angleName.LEFT_LOWER - angleClearance)
            {
                if (currentAngle < (int)angleName.LEFT_LOWER - angleClearance || currentAngle >= (int)angleName.RIGHT_UPPER)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
                if (currentAngle < (int)angleName.RIGHT_UPPER & currentAngle > (int)angleName.LEFT_LOWER + angleClearance)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        else if (Input.GetKey((KeyCode)KeyAssign.UPPER) & Input.GetKey((KeyCode)KeyAssign.LEFT))
        { //45
            if (currentAngle > (int)angleName.LEFT_UPPER + angleClearance || currentAngle < (int)angleName.LEFT_UPPER - angleClearance)
            {
                if (currentAngle >= (int)angleName.RIGHT_LOWER || currentAngle < (int)angleName.LEFT_UPPER - angleClearance)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
                if (currentAngle < (int)angleName.RIGHT_LOWER & currentAngle > (int)angleName.LEFT_UPPER + angleClearance)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        //上ボタン処理
        else if (Input.GetKey((KeyCode)KeyAssign.UPPER))
        {
            if (currentAngle > (int)angleName.UPPER + angleClearance & currentAngle < (int)angleName.UPPER2 - angleClearance)
            {
                if ((int)angleName.UPPER2 - angleClearance >= currentAngle)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
                else if ((int)angleName.UPPER + angleClearance < currentAngle)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }
            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        //下ボタン処理
        else if (Input.GetKey((KeyCode)KeyAssign.LOWER))
        {

            if (currentAngle < (int)angleName.LOWER - angleClearance || currentAngle > (int)angleName.LOWER + angleClearance)
            {
                if ((int)angleName.LOWER + angleClearance < currentAngle)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);

                }
                else if ((int)angleName.LOWER - angleClearance > currentAngle)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }

            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        //右ボタン処理
        else if (Input.GetKey((KeyCode)KeyAssign.RIGHT))
        {


            if (currentAngle < (int)angleName.RIGHT - angleClearance || currentAngle > (int)angleName.RIGHT + angleClearance)
            {
                if (currentAngle > (int)angleName.RIGHT + angleClearance || currentAngle <= (int)angleName.LEFT)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);

                }
                else if (currentAngle < (int)angleName.RIGHT - angleClearance & currentAngle > (int)angleName.LEFT)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }

            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }

        //左ボタン処理
        else if (Input.GetKey((KeyCode)KeyAssign.LEFT))
        {
            if (currentAngle < (int)angleName.LEFT - angleClearance || currentAngle > (int)angleName.LEFT + angleClearance)
            {
                if (currentAngle >= (int)angleName.RIGHT || currentAngle < (int)angleName.LEFT + angleClearance)
                {
                    transform.Rotate(0, 0, myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);

                }
                else if (currentAngle < (int)angleName.RIGHT & currentAngle > (int)angleName.LEFT - angleClearance)
                {
                    transform.Rotate(0, 0, -myPlayerClass.getAngleVelocity());
                    transform.localScale = new Vector3(playerScale * contractionRate, playerScale, 1);
                }

            }
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
        }
        else transform.localScale = new Vector3(playerScale, playerScale, 1);

        if(Input.GetKeyDown((KeyCode)KeyAssign.FLARE) && playerState != PlayerClass.PlayerState.FLARE && playerState != PlayerClass.PlayerState.DAMAGING)
        {
            setFlare();
        }

        if(Input.GetKey((KeyCode)KeyAssign.TRIGGER))
        {
            shootBullet();
        }
        /*

            if (Input.GetKey(KeyCode.S))
            {
                shotco++;
                if (shotco > 6)
                {
                    shotco = 0;
                    MisGene.GetComponent<misGenerater>().shoot(transform.position.x, transform.position.y, transform.localEulerAngles.z);
                }
            }
            */
    }

    private void setFlare()
    {
        if(myPlayerClass.shotFlare()){
            //フレア撃つ
        }else{
            //効果音とか。
        }
    }

    private void shootBullet()
    {
        if(shotPassedTime < shotCoolTime)
        {//クールタイム
            shotPassedTime += Time.deltaTime;
        }else{
            shotPassedTime = 0;

            GameObject bullet = Instantiate(bulletPrefab, bulletsFolderTransform) as GameObject;
            bullet.transform.position = muzzleTransform.position;
            bullet.transform.localEulerAngles = new Vector3(0, 0, this.transform.localEulerAngles.z);
            bullet.GetComponent<BulletController>().SetPlayerObject(this.gameObject);
            bullet.GetComponent<BulletController>().SetPlayerClass(this.myPlayerClass);
            bullet.GetComponent<BulletController>().SetShotSpeed(15.0f);//本当にここ？
        }
    }

    public void changeMoveSpeed(float speed)
    {
        myPlayerClass.setMoveSpeed(speed);
        SpeedChangeHandler?.Invoke(speed);
    }

    public PlayerClass GetPlayerClass(){
        return myPlayerClass;
    }
}
/*
    // Update is called once per frame
    void Update()
    {
        //
        if (startF)
        {
            if (Findstart == 0)
            {
                MisGene = GameObject.Find("misGenerater");
                efectgene = GameObject.Find("efectGenerater");
                scorer = GameObject.Find("score");
                Findstart = 1;
            }

            lco += 1;
            if (Pgamest != 2 && FGenerate == true)
            {
                if (lco > 3)
                {
                    lco = 0;
                    GameObject efectgene = GameObject.Find("efectGenerater");
                    efectgene.GetComponent<efectGenerater>().lineGene(0, 0, 1);
                }
            }
            switch (Pgamest)
            {

                case 0:
                    stco += 1;
                    if (stco > 60) Pgamest = 1;
                    break;

                case 1:
                    stco += 1;
                    transform.Rotate(0, 0, 3f);
                    transform.localScale = new Vector3(playerScale * 0.7f, playerScale, 1);
                    if (stco > 120)
                    {
                        stco = 0;
                        Pgamest = 3;
                    }
                    break;

                case 2:
                    if (SceneCheck == 1)
                    {
                        float currentAngle = transform.localEulerAngles.z;

                        if (Destroyflag == 1)
                        {
                            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
                            Destroyflag = 0;


                            foreach (GameObject mis in enemys)
                            {

                                Destroy(mis);
                            }
                        }

                        if (currentAngle > 3 & currentAngle < 357)
                        {
                            if (180 >= currentAngle)
                            {
                                transform.Rotate(0, 0, -yang);
                                transform.localScale = new Vector3(playerScale * -0.7f, playerScale, 1);
                            }
                            else if (180 < currentAngle)
                            {
                                transform.Rotate(0, 0, yang);
                                transform.localScale = new Vector3(playerScale * 0.7f, playerScale, 1);
                            }
                        }
                        else transform.localScale = new Vector3(playerScale, playerScale, 1);

                        if ((currentAngle > 357 || currentAngle < 3) & transform.position.y > -5)
                        {
                            transform.Translate(0, -0.1f, 0);
                        }
                    }
                    break;





                default:
                    if (SceneCheck == 1)
                    {
                        currentAngle = transform.localEulerAngles.z;

                        if (PLst == 4)
                        {
                            /*if ((responect > 0 && responect < 30) || (responect > 60 && responect < 90) || (responect > 120 && responect < 150))

                           {
                               col_a = col_a - (1/30); ;
                               GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col_a);
                           }
                           else
                           {
                               col_a = col_a + (1/30); ;
                               GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col_a);
                           }*/

                            /* if (responect > 180)
                             {
                                 PLst = 3;
                                 this.GetComponent<SpriteRenderer>().color = new Color(1,  1, 1);
                                 col_a = 1;
                             }
                             else
                             {
                                 this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
                             }
                            responect++;
                            if (responect > 150)
                            {
                                responect = 0;
                                PLst = 0;
                            }
                        }

                       

                        //フレア
                        if (Input.GetKeyDown(KeyCode.A) & PLst != 2)
                        {
                            if (Fpoint > 0)
                            {
                                for (fI = 0; fI < 6; fI++)
                                {
                                    efectgene.GetComponent<efectGenerater>().flareGene();
                                    PLst = 2;
                                }
                                Fpoint--;
                            }
                        }

                        if (PLst == 2)
                        {
                            PLFst += 1;

                            if (PLFst > 60)
                            {
                                PLFst = 0;
                                PLst = 0;

                            }
                        }

                        if (Input.GetKey(KeyCode.S))
                        {
                            shotco++;
                            if (shotco > 6)
                            {
                                shotco = 0;
                                MisGene.GetComponent<misGenerater>().shoot(transform.position.x, transform.position.y, transform.localEulerAngles.z);
                            }
                        }



                        stco++;
                        if (stco > 2880)
                        {
                            Pgamest = 2;
                            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
                            Destroyflag = 1;


                            foreach (GameObject mis in enemys)
                            {

                                Destroy(mis);
                            }

                        }


                    }
                    break;
            }


            if (SceneCheck == 2 && a == 0)
            {
                a = 1;
                this.transform.localScale = this.transform.localScale * 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (PLst != 4)
        {

            if ((other.tag == "enemy" || other.tag == "enemy1") && plZANKI == 0)
            {
                Destroy(gameObject);
                PLst = 1;
                //GameObject efectgene = GameObject.Find("lineGenerater");
                efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y, 1.5f);
            }
            else if (other.tag == "enemy" || other.tag == "enemy1")
            {
                efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y, 1);
                plZANKI = plZANKI - 1;
                PLst = 4;
            }
            else if (other.tag == "Item1")
            {
                scorer.GetComponent<scorecounter>().pointGet(300);
            }
            else if (other.tag == "Item2")
            {
                plZANKI += 1;
            }
            else if (other.tag == "Item3")
            {
                Fpoint += 1;
            }
        }

    }

    //だめだ、他スクリプトからの数値の書き換えができねぇ...シリーズ
    public void PLstChange(int st)
    {
        PLst = st;
    }
    public void PspeedChange(float speed)
    {
        Pspeed = speed;
    }
    public void Fgst(bool a)
    {
        FGenerate = a;
    }
    public void ZANKI(int zanki)
    {
        plZANKI = zanki;
    }
    public void FpointC(int Fpt)
    {
        Fpoint = Fpt;
    }
    public void ScenecheckP1(int Scene)
    {
        SceneCheck = Scene;
    }
    public void SceneDestroy()
    {

        Destroy(gameObject);
    }
    */

