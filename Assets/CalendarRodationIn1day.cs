using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarRodationIn1day : MonoBehaviour {

    public GameObject m_cube;//axis
    public GameObject m_day;
    public GameObject m_today;
    Vector3 m_axis = new Vector3(1, 0, 0);
    static int frameindex = 0;
    static int framewait = 100;

    void Update()
    {
        if (framewait > 0)
        {
            framewait--;
            return;
        }
        if (frameindex<12)
        {
            m_day.transform.RotateAround(m_cube.transform.position, m_axis, 1);
        }
        if (frameindex < 349)
        {            
            m_today.transform.RotateAround(m_cube.transform.position, m_axis, 1);
            frameindex++;
        }

    }
}
