using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerater : MonoBehaviour {

    public GameObject POINt;
    public GameObject LIFe;
    public GameObject FLARe;
    private int pointct;
    private int Lifect;
    private int Flarect;
    float Px, Py;
    float ax,ay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pointct > 2)
        {
            GameObject pointp = Instantiate(POINt) as GameObject;
            ax = Random.Range(-0.1f, 0.1f);
            ay = Random.Range(-0.1f, 0.1f);
            pointp.transform.position = new Vector3(Px+ax,Py+ay,0);
            pointct = 0;
         }
        if (Flarect > 5)
        {
            GameObject flarep = Instantiate(FLARe) as GameObject;
            ax = Random.Range(-0.1f, 0.1f);
            ay = Random.Range(-0.1f, 0.1f);
            flarep.transform.position = new Vector3(Px + ax, Py + ay, 0);
            Flarect = 0;
        }
        if (Lifect > 9)
        {
            GameObject lifep = Instantiate(LIFe) as GameObject;
            ax = Random.Range(-0.1f, 0.1f);
            ay = Random.Range(-0.1f, 0.1f);
            lifep.transform.position = new Vector3(Px + ax, Py + ay, 0);
            Lifect = 0;
        }
    }

    public void Hitcheck(float x,float y)
    {
        Px = x;
        Py = y;
        pointct++;
        Lifect++;
        Flarect++;
    }
    
}



