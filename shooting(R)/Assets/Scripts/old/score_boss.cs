using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_boss : MonoBehaviour {

    int ct;
    public static int scoreb;
    public Text myText;
    int HP = 100;
    float time;
    int TIME;
	// Use this for initialization
	void Start () {
        scoreb = scorecounter.score;
	}
	
	// Update is called once per frame
	void Update () {

        if (ct < 120) ct++;
        else if (ct < 240)
        {


            ct++;
            myText.text = "The boss of\n your enemy appeared!!";



        }
        else
        {

            time += Time.deltaTime;

            if (time >= 1)
            {
                time = 0;
                TIME++;
            }
            myText.text = "Score " + scoreb + "\nTIME " + TIME + "\n Boss HP " + HP;
        }

    }
    public void bossDamage(int Damage)
    {
        HP = Damage;
    } 
    public void crearGet()
    {
        scoreb += 1000;
        scoreb += (playerController.plZANKI * 500);
        if (TIME < 120)
        {
            scoreb += (120 - TIME);
        }
        
    }
}
