using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSnowAnimation : MonoBehaviour {
    public static int speed =30;// 20 frame
    Material shader1;
    Material shader2;
    Material shader3;
    Renderer rend;
    static int framindex = 0;
    static int a = 0;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        shader1 = Resources.Load("snowy0",typeof(Material)) as Material;
        shader2 = Resources.Load("snowy", typeof(Material)) as Material;
        shader3 = Resources.Load("snowy1", typeof(Material)) as Material;
        framindex = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (framindex < speed)
        {
            framindex++;
        }
        else
        {
            if (a == 0)
            {
                rend.material = shader1;
                a++;
            }
            else if(a==1)
            {
                rend.material = shader2;
                a++;
            }
            else
            {
                rend.material = shader3;
                a=0;
            }
                
            framindex = 0;
        }

    }
}
