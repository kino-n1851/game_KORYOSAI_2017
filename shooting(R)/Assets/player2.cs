using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {

    //PLst 0-> alive 1-> dead 2-> flare
    //あ、スパゲッティおかわりですか？
    //どうぞめしあがれ.....

    int fI, PLFst = 0;
    float yang = 3.5f;
    float stco, lco;
    int Pgamest = 0;
    float pscale = 0.4f;
    private float col_a = 1.0f;
    //float pv = 0.05f;
    private int plst; 
    //public static float Pspee = 0.60f;
    private int plZANKI;
    int responect;
    int shotco;
    GameObject efectgene;
    GameObject Plscr;//
    GameObject MisGene;
    int Fpoint;
    

    // Use this for initialization
    void Start()
    {
        Fpoint = playerController.Fpoint;
        plZANKI = playerController.plZANKI;
        efectgene = GameObject.Find("efectGenerater");
        Plscr = GameObject.Find("player");
        MisGene = GameObject.Find("misGenerater");
        Plscr.GetComponent<playerController>().Fgst(false);
        Plscr.GetComponent<playerController>().PLstChange(0);
        responect = 0;
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Plscr.GetComponent<playerController>().PLstChange(0);
        

    }

    // Update is called once per frame
    void Update()
    {

        Fpoint = playerController.Fpoint;
        plst = playerController.PLst;
        switch (Pgamest)
        {
            case 0:
                stco++;
                if (stco >= 250)
                {
                    stco = 0;
                    Pgamest = 1;
                }
                break;


            case 1:
                stco += 1;
                transform.Rotate(0, 0, 4f);
                transform.localScale = new Vector3(0.35f * 0.7f, 0.35f, 1);
                if (stco > 44)
                {
                    Pgamest = 2;
                    stco = 0;
                }
                break;

            case 2:
                stco++;
                transform.Translate(0, -0.1f, 0);
                if (stco > 50) Pgamest = 3;

                break;

            
            default:
                float pR = transform.localEulerAngles.z; pR = transform.localEulerAngles.z;


                if (playerController.PLst == 4)
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
                    
                    /*if (responect > 180)
                    {
                        Plscr.GetComponent<playerController>().PLstChange(3);
                        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
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
                        Plscr.GetComponent<playerController>().PLstChange(0);
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
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (Fpoint > 0)
                    {
                        for (fI = 0; fI < 6; fI++)
                        {
                            efectgene.GetComponent<efectGenerater>().flareGene();

                        }
                        Plscr.GetComponent<playerController>().PLstChange(2);
                        
                    }
                }

                if (plst == 2)
                {
                    PLFst += 1;

                    if (PLFst > 65)
                    {
                        PLFst = 0;
                        Plscr.GetComponent<playerController>().PLstChange(0);
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

                break;
        }

        

        lco += 1;
        if (lco > 3)
        {
            lco = 0;
            GameObject efectgene = GameObject.Find("efectGenerater");
            efectgene.GetComponent<efectGenerater>().lineGene(this.transform.position.x, this.transform.position.y,1);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerController.PLst != 4)
        {
            if ((other.tag == "enemy" || other.tag == "Senemy") && plZANKI == 0)
            {
                Destroy(gameObject);
                Plscr.GetComponent<playerController>().PLstChange(1);
                //GameObject efectgene = GameObject.Find("lineGenerater");
                efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y,1.5f);
            }

            else if (other.tag == "enemy" || other.tag == "Senemy")
            {
                efectgene.GetComponent<efectGenerater>().bombGene(this.transform.position.x, this.transform.position.y,1);
                plZANKI = plZANKI - 1;
                Plscr.GetComponent<playerController>().ZANKI(plZANKI);
                Plscr.GetComponent<playerController>().PLstChange(4);

            }
        }
    }

    
}


