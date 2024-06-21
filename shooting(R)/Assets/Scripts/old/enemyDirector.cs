﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour {

    float delta = 0;
    float span = 0.1f;
    int[] genest;
    int[] Easyst;
    int[] Hardst;
    int[] Lunast;
    int loopt;
    int i;
    GameObject misGene;
   
    //0　なし　1　誘導　2　直線

    // Use this for initialization
	void Start () {
        genest = new int[500];

        //0　なし　1　誘導　2　直線
        //0　なし　1　誘導　2　直線
        Easyst = new int[500]
   
        {
         0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,1,0,1,0,1,0,0,
         0,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,2,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,
         1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,2,0,2,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,
         0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,
         0,0,1,0,0,0,1,0,0,0,2,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,
         2,0,0,0,0,0,1,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,0,0,0,2,0,2,0,2,0,2,0,2,0,0,0,0,0,0,0,
         0,0,1,0,0,0,0,0,0,2,0,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,
         2,0,0,0,0,0,1,0,2,0,0,0,1,0,1,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,0,0,0,1,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,
         0,0,0,0,1,0,2,0,0,0,2,0,2,0,2,0,0,0,1,0,1,0,1,0,2,0,1,0,0,0,0,0,0,0,0,2,0,0,0,2,0,1,0,2,0,1,0,1,0,0,
         2,0,2,0,2,0,1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
         //                                                               ↑ここまで
        };

        Hardst = new int[500]
        {
         0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,0,0,1,0,0,0,1,0,2,0,0,0,1,0,1,0,1,0,0,
         0,2,0,0,0,0,0,0,0,2,0,2,0,2,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,1,0,1,0,2,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,
         1,0,0,2,0,2,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,2,0,2,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,
         0,0,0,0,0,0,0,1,0,0,0,0,2,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,
         0,0,1,0,0,0,1,0,0,0,2,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,1,
         2,0,0,0,0,0,1,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,0,0,0,2,0,2,0,2,0,2,2,2,0,0,0,0,0,0,0,
         0,0,1,0,0,0,0,0,0,2,0,0,0,1,0,1,0,1,0,1,1,1,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,
         2,0,0,0,0,0,1,0,2,0,0,0,1,0,1,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,0,0,0,1,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,
         2,2,2,2,1,0,2,0,0,0,2,0,2,0,2,0,0,0,1,0,1,0,1,0,2,0,1,1,0,1,0,1,0,0,0,2,0,0,0,2,0,1,0,2,0,1,0,1,0,0,
         2,0,2,1,2,0,1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
         //                                                               ↑ここまで
        };

        Lunast = new int[500]
        {
         0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,0,0,1,0,0,0,1,0,2,2,2,0,1,0,1,1,1,0,0,
         0,2,0,0,1,1,1,0,0,2,0,2,0,2,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,1,0,1,0,2,0,1,0,0,2,0,2,0,2,0,0,1,0,0,0,0,
         1,0,0,2,2,2,0,1,0,1,1,0,1,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,2,0,2,0,0,0,0,1,0,0,0,0,1,2,2,2,2,2,0,
         0,0,0,0,1,0,1,1,0,2,0,0,2,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,
         0,0,1,0,0,0,1,0,0,0,2,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,2,0,0,0,2,0,0,1,1,1,1,0,0,0,0,0,2,0,0,0,2,0,0,1,
         2,0,0,0,0,0,1,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,2,0,0,0,1,0,0,0,2,0,2,0,2,0,2,2,2,0,0,1,1,1,0,0,
         0,0,1,0,0,0,0,0,0,2,0,0,0,1,0,1,0,1,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
         2,2,2,2,2,2,1,0,2,0,0,0,1,0,1,0,0,0,2,0,0,0,2,0,0,0,2,1,1,1,1,0,0,0,1,0,2,2,0,1,1,2,2,0,0,0,0,0,0,0,
         2,2,2,2,1,0,2,1,2,1,2,0,2,1,2,1,2,2,1,0,1,0,1,0,2,0,1,1,1,1,1,1,1,1,1,2,0,0,0,2,0,1,0,2,0,1,0,1,0,0,
         2,0,2,2,2,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
         //                                 
        };
        

        if (ChooseC.Difficulty == 0)
        {
            for (i = 0; i < 500;i++)
                {
                genest[i] = Easyst[i];
                }
                
        }else if (ChooseC.Difficulty == 1)
        {
            for (i = 0; i < 500; i++)
            {
                genest[i] = Hardst[i];
            }
        }
        else if (ChooseC.Difficulty == 2)
        {
            for (i = 0; i < 500; i++)
            {
                genest[i] = Lunast[i];
            }
        }

        misGene = GameObject.Find("misGenerater");
    }
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            loopt = loopt % 500;
            switch (genest[loopt])
            {
                case 0:
                   
                    break;

                case 1:
                    misGene.GetComponent<misGenerater>().mis1ap();
                   
                    break;

                case 2:
                    misGene.GetComponent<misGenerater>().mis2ap();
                   
                    break;

            }
        loopt++;
            
        }
	}
}
