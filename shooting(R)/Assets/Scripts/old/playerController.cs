using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //PLst 0-> alive 1-> dead 2-> flare

    int Destroyflag;
    int fI, PLFst = 0;
    public static int Fpoint;
    float yang = 3.5f;
    float stco, lco;
    int Pgamest = 0;
    public float pscale = 0.4f;
    private float col_a = 1.0f;
    public static int SceneCheck = 1;
    int responect;
    int shotco;
    int a = 0;
    private float pR;
    int Findstart = 0;
    //float pv = 0.05f;

    public static int PLst = 0;
    public static float Pspeed = 0.60f;
    public static int plZANKI = 15;
    private bool FGenerate;
    private bool startF = false;

    GameObject efectgene;
    GameObject MisGene;
    GameObject scorer;

    
    // Use this for initialization
    void Start()
    {
        startF = false;
        plZANKI = 15;
        Pspeed = 0.60f;
        PLst = 0;
        SceneCheck = 1;
        Fpoint = 5;
        responect = 0;
        //plZANKI = 3;
        FGenerate = true;
        PLst = 0;
        MisGene = GameObject.Find("misGenerater");
        efectgene = GameObject.Find("efectGenerater");
        scorer = GameObject.Find("score");
        Pspeed = 0.60f;
        Pgamest = 0;
        //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        col_a = 1.0f;
        SceneCheck = 1;
        Debug.Log(SceneCheck);
        DontDestroyOnLoad(this.gameObject);

        

    }

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
                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                    if (stco > 120)
                    {
                        stco = 0;
                        Pgamest = 3;
                    }
                    break;

                case 2:
                    if (SceneCheck == 1)
                    {
                        float pR = transform.localEulerAngles.z;

                        if (Destroyflag == 1)
                        {
                            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
                            Destroyflag = 0;


                            foreach (GameObject mis in enemys)
                            {

                                Destroy(mis);
                            }
                        }

                        if (pR > 3 & pR < 357)
                        {
                            if (180 >= pR)
                            {
                                transform.Rotate(0, 0, -yang);
                                transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                            }
                            else if (180 < pR)
                            {
                                transform.Rotate(0, 0, yang);
                                transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                            }
                        }
                        else transform.localScale = new Vector3(pscale, pscale, 1);

                        if ((pR > 357 || pR < 3) & transform.position.y > -5)
                        {
                            transform.Translate(0, -0.1f, 0);
                        }
                    }
                    break;





                default:
                    if (SceneCheck == 1)
                    {
                        pR = transform.localEulerAngles.z;

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
                             }*/
                            responect++;
                            if (responect > 150)
                            {
                                responect = 0;
                                PLst = 0;
                            }
                        }

                        if (Input.GetKey(KeyCode.I) & Input.GetKey(KeyCode.L))
                        { //315
                            if (pR > 317 || pR < 313)
                            {
                                if (pR <= 135 || pR > 317)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                                }
                                if (pR < 313 & pR > 135)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }
                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        else if (Input.GetKey(KeyCode.K) & Input.GetKey(KeyCode.L))
                        { //225
                            if (pR > 227 || pR < 223)
                            {
                                if (pR <= 45 || pR > 227)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                                }
                                if (pR < 223 & pR > 45)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }
                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        else if (Input.GetKey(KeyCode.K) & Input.GetKey(KeyCode.J))
                        { //135
                            if (pR > 137 || pR < 133)
                            {
                                if (pR < 133 || pR >= 315)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }
                                if (pR < 315 & pR > 137)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                                }
                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        else if (Input.GetKey(KeyCode.I) & Input.GetKey(KeyCode.J))
                        { //45
                            if (pR > 47 || pR < 43)
                            {
                                if (pR >= 225 || pR < 43)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }
                                if (pR < 225 & pR > 47)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                                }
                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        //上ボタン処理                  
                        else if (Input.GetKey(KeyCode.I))
                        {
                            if (pR > 3 & pR < 357)
                            {
                                if (180 >= pR)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                                }
                                else if (180 < pR)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }
                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        //下ボタン処理
                        else if (Input.GetKey(KeyCode.K))
                        {

                            if (pR < 178 || pR > 182)
                            {
                                if (182 < pR)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);

                                }
                                else if (178 > pR)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }

                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        //右ボタン処理
                        else if (Input.GetKey(KeyCode.L))
                        {


                            if (pR < 267 || pR > 273)
                            {
                                if (pR > 270 || pR <= 90)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);

                                }
                                else if (pR < 270 & pR > 90)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);
                                }

                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }

                        //左ボタン処理
                        else if (Input.GetKey(KeyCode.J))
                        {


                            if (pR < 88 || pR > 92)
                            {
                                if (pR >= 270 || pR < 88)
                                {
                                    transform.Rotate(0, 0, yang);
                                    transform.localScale = new Vector3(pscale * 0.7f, pscale, 1);

                                }
                                else if (pR < 270 & pR > 92)
                                {
                                    transform.Rotate(0, 0, -yang);
                                    transform.localScale = new Vector3(pscale * -0.7f, pscale, 1);
                                }

                            }
                            else transform.localScale = new Vector3(pscale, pscale, 1);
                        }
                        else transform.localScale = new Vector3(pscale, pscale, 1);

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
    public void startFl(bool st)
    {
        startF = st;
    }
    public void Reset()
    {
        fI = 0;
        PLFst = 0;
        yang = 3.5f;
        stco = 0;
        lco = 0;
        Pgamest = 0;
        pscale = 0.4f;
        col_a = 1.0f;
        Fpoint = 5;
        SceneCheck = 1;
        responect = 0;
        shotco = 0;
        a = 0;
        pR = 0;
        Findstart = 0;
        FGenerate = true;
        PLst = 0;
        Pspeed = 0.60f;
        plZANKI = 15;
   
        startF = false;
        this.transform.localScale = new Vector3(0.4f,0.4f,1);
        this.transform.position = new Vector3(0,0,1);
    }
    public void ScaleReset()
    {
        this.gameObject.transform.localScale = new Vector3(0.4f,0.4f,1);
        pscale = 0.4f;
    }
}

   