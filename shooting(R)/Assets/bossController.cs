using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossController : MonoBehaviour {

    private float col_a;
    private int startct;
    private float pang, pvx, pvy;
    private float pspeed;
    private int bossAct;
    private int bossMct;
    private int Acti = 2;
    private int Atime = 0;
    private int AttackP;
    private float Tang,vang = 0.3f;
    private float bossScx = 8;
    private float bossScy = 7;
    float bossSC = 1;
    public int Hitpoint = 100;
    float mx, my, m1x, m1y, m3x,m3y, angle1, angle2;
    int m1co,m2co,m3co;
    int bosslife =0;
    float ScM = 0;
    float Aa;
    int crearct;
    int IconTime;
    float Bpx, Bpy;
    int BG1, BG2, BG3;
    Vector3 pvd;
    GameObject player;
    GameObject misgene;
    GameObject efect;
    GameObject HPco;
    GameObject scorer;
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);

        if (playerController.SceneCheck == 1) { player = GameObject.Find("player"); }
        else if (playerController.SceneCheck == 2) { player = GameObject.Find("player2"); }

        pang = player.transform.localEulerAngles.z;

        pspeed = playerController.Pspeed;
        misgene = GameObject.Find("misGenerater");
        efect = GameObject.Find("efectGenerater");
        HPco = GameObject.Find("score");

        if(ChooseC.Difficulty == 0)
        {
            BG1 = 12;
            BG2 = 18;
            BG3 = 60;
        }else if (ChooseC.Difficulty == 1)
        {
            BG1 = 8;
            BG2 = 12;
            BG3 = 40;
        }
        else if (ChooseC.Difficulty == 2)
        {
            BG1 = 6;
            BG2 = 6;
            BG3 = 20;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (startct < 120)
        {
            startct++;
        }
        else if (startct <320)
        {
            startct++;
            if (col_a < 1)col_a += 0.01f;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col_a);
            if (transform.position.y > 15)
            {
                transform.Translate(0, 0.12f, 0);
            }
        }
        else
        {
            bossMct++;
            
            if(bossMct > 300)
            {
                Acti = Random.Range(0,6);
                bossMct = 0;
                ScM = 1;
                if (Acti == 0 || Acti == 1)
                {
                    Tang = Random.Range(15,90);
                    vang = Tang / 300;
                }

            }
            

           
             if(Acti == 0)
            {   if (bossMct < 50) ScM -= vang*0.02f;
                else if (bossMct > 250) ScM += vang*0.02f;
                transform.Rotate(0, 0, vang);
                transform.localScale = new Vector3(bossScx*-ScM,bossScy,0);

                
            }
            else if(Acti == 1)
            {
                if (bossMct < 50) ScM -= vang*0.02f;
                else if (bossMct >250)ScM += vang*0.02f;
                transform.Rotate(0, 0, -vang);
                transform.localScale = new Vector3(bossScx*ScM, bossScy, 0);
            }
            else
            {
                transform.localScale = new Vector3(bossScx, bossScy, 0);
            }

            bossAct++;

            if (bossAct > 1200)
            {
                Atime = 600;
                bossAct = 0;
                AttackP = Random.Range(0, 3);
                
               
            }

            if (Atime > 0 && bosslife == 0 )
            {
                switch (AttackP)
                {
                    case 0:
                        m1co++;
                        if (m1co > BG1)
                        {
                            mx = transform.position.x;
                            my = transform.position.y;

                            angle1 = Random.Range(0, 360);
                            misgene.GetComponent<misGenerater>().mis3boss(mx, my, angle1);
                            m1co = 0;
                        }
                        break;

                    case 1:
                        m2co++;
                        if (m2co > BG2)
                        {
                            mx = transform.position.x;
                            my = transform.position.y;

                            angle1 = 1;
                            misgene.GetComponent<misGenerater>().mis2boss(mx, my, angle1);
                            m2co = 0;
                        }
                        break;

                    case 2:
                        m3co++;
                        if (m3co > BG3)
                        {
                            
                            //angle2 = this.transform.rotation.z * 180 * Mathf.Deg2Rad;

                            angle1 = this.transform.rotation.z + 180;
                            m1y = transform.position.y; //+ Mathf.Sin(angle2)*5;
                            m1x = transform.position.x;//+ Mathf.Cos(angle2)*5;
                            


                            
                            misgene.GetComponent<misGenerater>().mis1boss(m1x, m1y, angle1);
                            m3co = 0;
                        }
                        break;
                }
                Atime--;
            }

            if (playerController.PLst != 1 )
                
            {
                pang = this.player.transform.localEulerAngles.z;

                pvy = Mathf.Cos(pang * Mathf.Deg2Rad) * -pspeed;
                pvx = Mathf.Sin(pang * Mathf.Deg2Rad) * pspeed;

                pvd = new Vector3(pvx, pvy, 0);


                transform.position = transform.position + pvd;
            }

            transform.Translate(0,0.15f,0);
            IconTime++;

            Bpx = transform.position.x;
            Bpy = transform.position.y;

            if (Bpx > 130)
            {
                transform.position = new Vector3(130, Bpy, 0);
            }
            if (Bpx < -130)
            {
                transform.position = new Vector3(-130, Bpy, 0);
            }
            if (Bpy > 120)
            {
                transform.position = new Vector3(Bpx, 120, 0);
            }
            if (Bpy < -120)
            {
                transform.position = new Vector3(Bpx, -120, 0);
            }
            if(IconTime > 180)
            {
                if (Bpx > 70 && Bpy > 40) efect.GetComponent<efectGenerater>().attention(27,14);
                else if (Bpx > 70 && Bpy < -40) efect.GetComponent<efectGenerater>().attention(27,-14);
                else if (Bpx < -70 && Bpy < -40) efect.GetComponent<efectGenerater>().attention(-27,-14);
                else if (Bpx < -70 && Bpy > 40) efect.GetComponent<efectGenerater>().attention(-27,14);
                else if (Bpx > 70) efect.GetComponent<efectGenerater>().attention(27,0);
                else if (Bpx < -70) efect.GetComponent<efectGenerater>().attention(-27,0);
                else if (Bpy > 40) efect.GetComponent<efectGenerater>().attention(0,14);
                else if (Bpy < -40) efect.GetComponent<efectGenerater>().attention(0,-14);
                else
                {
                    IconTime = 0;
                }
               
            }
        }

        if (Hitpoint <= 0)

        {
            
           
    
            efect.GetComponent<efectGenerater>().bombGene(transform.position.x,transform.position.y,3);
            Hitpoint = 0;
            bosslife = 1;
            crearct++;
            if (bossSC > 0)
            {
                bossSC -= 0.003f;
            }
            transform.localScale = transform.localScale * bossSC;
            if (crearct > 480)
            {
                HPco.GetComponent<score_boss>().crearGet();
                Destroy(gameObject,8);
                SceneManager.LoadScene("crear scene_shooting");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "shot")
        {
            Hitpoint--;
            HPco.GetComponent<score_boss>().bossDamage(Hitpoint);
        }
    }
}
