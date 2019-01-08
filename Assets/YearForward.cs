using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class YearForward : MonoBehaviour {
    public List<GameObject> m_list = new List<GameObject>(13);
    public GameObject m_cube;//axis
    private static int waitingtime = 100;
    public static int switchtime = 20;
    private static int switchtime_in = 5;
    private static int objindex = 0;
    Vector3 m_axis = new Vector3(1, 0, 0);
    Vector3 m_move = new Vector3(0, 0, 0);
    static int degreeacumulate = 0;
    public float switchspeed = 2f;
    private int daysindex = 1;
    private int indexstart = 16;
    //private bool RStatus = false;//true: rotating, false:finished
    // Use this for initialization
    void Start()
    {
        switchtime_in = switchtime;

    }

    // Update is called once per frame
    void Update()
    {
        if (waitingtime > 0)
        {
            /*if(waitingtime > 69 && indexstart <31)
            {
                GameObject temp = GameObject.Find(m_list[objindex].name + "/" + "Canvas (1)/Image" + indexstart.ToString());
                temp.GetComponent<Image>().enabled = true;
                indexstart++;
            }  */          
            waitingtime--;
            return;
        }
        if (switchtime_in > 0)
        {
            if(objindex==0)
            {
                if(indexstart < 31)
                {
                    GameObject temp = GameObject.Find(m_list[objindex].name + "/" + "Canvas (1)/Image" + indexstart.ToString());
                    temp.GetComponent<Image>().enabled = true;
                    indexstart++;
                }
                
            }
            else if (switchtime_in<15 && objindex<12)
            {
                GameObject temp = GameObject.Find(m_list[objindex].name + "/" + "Canvas (1)");
                temp.GetComponent<Canvas>().enabled = true;
            }
            switchtime_in--;
        }
        else if (objindex < 12)
        {
            
            m_list[objindex ].transform.RotateAround(m_cube.transform.position, m_axis, 1 * switchspeed);//100*Time.deltaTime
            degreeacumulate += (int)switchspeed;
            float tempd = m_list[objindex + 1].transform.position.z - m_cube.transform.position.z;
            if (degreeacumulate > 10)
            {
                m_move = m_list[objindex+1].transform.position;
                m_move.z = m_cube.transform.position.z;
                m_list[objindex+1].transform.position = m_move;
            }
            if (degreeacumulate > 340)
            {
                m_move = m_list[objindex].transform.position;
                m_move.z += 0.1f;
                m_list[objindex].transform.position = m_move;

                objindex++;
                degreeacumulate = 0;
                switchtime_in = switchtime;                
            }
        }
        else if (daysindex < 15)
        {
            GameObject temp = GameObject.Find(m_list[objindex].name + "/" + "Canvas (1)/Image" + daysindex.ToString());
            temp.GetComponent<Image>().enabled = true;
            daysindex++;
        }
    }
}
