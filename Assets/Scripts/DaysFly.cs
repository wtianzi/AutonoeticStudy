using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DaysFly : MonoBehaviour {
    
    public int refreshrate=1;//change one day every frame
    private static int totalframe;
    public Material m_material;
    private Renderer m_renderer;
    // Use this for initialization
    void Start () {
        totalframe = 0;
        if (m_renderer == null)
            m_renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        totalframe++;
        if (totalframe > 4* refreshrate)
            totalframe = 1;
        int i = totalframe / refreshrate;
        if(i>0 && i<4)
        {
            String tmpchar = String.Format("201704{0}", i);
            Texture yyy= Resources.Load(tmpchar) as Texture;
            m_material.mainTexture = Resources.Load(tmpchar) as Texture;
            m_renderer.material = m_material;
        }
        

    }
}
