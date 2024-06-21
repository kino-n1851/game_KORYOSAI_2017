using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misGenerater : MonoBehaviour
{

    public GameObject mis1;
    public GameObject mis1b;
    public GameObject mis2;
    public GameObject mis3;
    public GameObject shot;

    GameObject LaserGe;

    float ax, ay;
    float gct, ct;
    float ex, ey, ang;
    int gm1st;

    // Update is called once per frame
    void Start()
    {

        LaserGe = GameObject.Find("efectGenerater");

    }


    public void mis1ap()
    {

        gm1st = Random.Range(0, 3);
        switch (gm1st)
        {

            case 0:
                ex = Random.Range(-30, 31);
                ey = 20;
                break;
            case 1:
                ex = Random.Range(-30, 31);
                ey = -20;
                break;
            case 2:
                ex = 30;
                ey = Random.Range(-20, 21);
                break;
            default:
                ex = -30;
                ey = Random.Range(-20, 21);
                break;
        }
        GameObject mis1p = Instantiate(mis1) as GameObject;
        mis1p.transform.position = new Vector3(ex, ey, 0);
        /* if (ex > 16) ax = 16.5f;
         if (ex < -16) ax = -16.5f;
         if (ey > 9) ay = 9.0f;
         if (ey < -9) ay = -9.0f;

         LaserGe.GetComponent<efectGenerater>().attention(ax,ay);*/

    }



    public void mis2ap()
    {

        gm1st = Random.Range(0, 3);
        switch (gm1st)
        {

            case 0:
                ex = Random.Range(-35, 36);
                ey = 25;
                break;
            case 1:
                ex = Random.Range(-35, 36);
                ey = -25;
                break;
            case 2:
                ex = 35;
                ey = Random.Range(-25, 26);
                break;
            default:
                ex = -35;
                ey = Random.Range(-25, 26);
                break;
        }
        GameObject mis2p = Instantiate(mis2) as GameObject;
        mis2p.transform.position = new Vector3(ex, ey, 0);

       



    }



    public void mis1boss(float m1x,float m1y,float angle1)
    {

        
        GameObject mis1_b = Instantiate(mis1b) as GameObject;
        mis1_b.transform.position = new Vector3(m1x, m1y, 0);
        mis1_b.transform.rotation = Quaternion.Euler(0, 0, angle1);
        

    }

    public void mis2boss(float m2x,float m2y, float angle2)
    {

        
        GameObject mis2p = Instantiate(mis2) as GameObject;
        mis2p.transform.position = new Vector3(m2x, m2y, 0);
        mis2p.transform.rotation = Quaternion.Euler(0,0,0);
        


    }

    public void mis3boss(float m3x, float m3y, float angle3)
    {


        GameObject mis3p = Instantiate(mis3) as GameObject;
        mis3p.transform.position = new Vector3(m3x, m3y, 0);
        mis3p.transform.rotation = Quaternion.Euler(0, 0, angle3);


        LaserGe.GetComponent<efectGenerater>().laserGene(m3x, m3y, angle3);



    }

    public void shoot(float shotx,float shoty,float ang)
    {
        GameObject shotp = Instantiate(shot) as GameObject;
        shotp.transform.position = new Vector3(shotx, shoty, 0);
        shotp.transform.rotation = Quaternion.Euler(0, 0, ang);

    }
}
/*            
                gm1st = Random.Range(0, 3);
                switch (gm1st)
                {

                    case 0:
                        ex = Random.Range(-9, 10);
                        ey = 6;
                        break;
                    case 1:
                        ex = Random.Range(-9, 10);
                        ey = -6;
                        break;
                    case 2:
                        ex = 9;
                        ey = Random.Range(-6, 7);
                        break;
                    default:
                        ex = -9;
                        ey = Random.Range(-6, 7);
                        break; 
                }
                GameObject mis1p = Instantiate(mis1) as GameObject;
                mis1p.transform.position = new Vector3(ex, ey, 0);

            }
            break;

        case 1:

            delta += Time.deltaTime;
            if (delta > span2)
            {
                delta = 0;
                gm1st = Random.Range(0, 3);
                switch (gm1st)
                {

                    case 0:
                        ex = Random.Range(-9, 10);
                        ey = 6;
                        break;
                    case 1:
                        ex = Random.Range(-9, 10);
                        ey = -6;
                        break;
                    case 2:
                        ex = 9;
                        ey = Random.Range(-6, 7);
                        break;
                    default:
                        ex = -9;
                        ey = Random.Range(-6, 7);
                        break;
                }
                GameObject mis2p = Instantiate(mis2) as GameObject;
                mis2p.transform.position = new Vector3(ex, ey, 0);

            }

            break;
    }*/


//}
