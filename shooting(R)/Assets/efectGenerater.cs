using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efectGenerater : MonoBehaviour {

	public GameObject linep;
    public GameObject bombp;
    public GameObject flarep;
    public GameObject laserp;
    public GameObject attentionp;
    static private int Fno = 0;

	// Update is called once per frame
	void Update () {
		
	}

    public void laserGene (float lax,float lay,float laR)
    {
       
        GameObject LASER = Instantiate(laserp) as GameObject;
        LASER.transform.position = new Vector3(lax, lay, 0);
        LASER.transform.rotation = Quaternion.Euler(0, 0, laR);
       
    }

    public void attention(float ax,float ay)
    {
        GameObject Attention = Instantiate(attentionp) as GameObject;
        Attention.transform.position = new Vector3(ax,ay,0);
    }


    public void lineGene (float lx,float ly,float lsc){
        GameObject line = Instantiate(linep) as GameObject;
        line.transform.position = new Vector3(lx,ly,0);
        line.transform.localScale = line.transform.localScale * lsc;
    }

    public void bombGene (float bx, float by,float scale)
    {
        GameObject Bomb = Instantiate(bombp) as GameObject;
        Bomb.transform.position = new Vector3(bx, by, 0);
        Bomb.transform.localScale = Bomb.transform.localScale * scale;

    }

    public void flareGene ()
    {
        GameObject Flare = Instantiate(flarep) as GameObject;
        Flare.transform.position = new Vector3(0, 0, 0);
        string no = string.Format("{0}",Fno);
        Flare.name = "Flare"+ no;
        Fno++;
        if (Fno >= 6)
        {
            Fno = 0;
        }
    }


  

}
