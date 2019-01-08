using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class DaysFlyCanvas_frame : MonoBehaviour {
    public List<GameObject> m_list=new List<GameObject>(26);
    //private List<Image> m_images = new List<Image>(28);
    private static int m_index=0;
    public int rateofupdate=100;
    private static int m_times=0;
    public bool rotationmark=false;
    public int waitingframes = 20;/////////////////////
    private static int waitingtime=0;
    private void Start()
    {        
        foreach (GameObject t_obj in m_list)
        {
            t_obj.GetComponent<Image>().enabled = false;
        }
        waitingtime = waitingframes;
    }
    private void Update()
    {
        if(!rotationmark && waitingtime<0)
        {
            if (m_index > m_list.Count - 1)
            {
                m_index = 0;
                rotationmark = true;
            }
            else
            {
                m_list[m_index].GetComponent<Image>().enabled = true;
                m_index++;
            }
            waitingtime = waitingframes;
        }
        else
        {
            waitingtime--;
        }
        
              
       
    }
    private void ResetImageList()
    {
        //rotation
        rotationmark = true;
        //set to original status    
        for (int i=0;i< m_index;i++)
            m_list[i].GetComponent<Image>().enabled = false;
        

    }

}
