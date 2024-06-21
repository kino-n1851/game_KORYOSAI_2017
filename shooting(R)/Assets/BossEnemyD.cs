using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyD : MonoBehaviour
{

    float delta = 0;
    float span = 0.2f;
    int[] genest;
    int loopt;
    GameObject misGene;

    //0　なし　1　誘導　2　直線

    // Use this for initialization
    void Start()
    {
        genest = new int[250]
    //0　なし　1　誘導　2　直線
    //0　なし　1　誘導　2　直線
        {
         0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
         0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
         1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,
         0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,
         0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,

        };
        misGene = GameObject.Find("misGenerater");
    }

    // Update is called once per frame
    void Update()
    {/*
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            loopt = loopt % 250;
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

        }*/
    }
}