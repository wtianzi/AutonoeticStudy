using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarRotation12days : MonoBehaviour {

    public GameObject m_cube;//axis
    public List<GameObject> m_days = new List<GameObject>(12);//today, 1 day ago, 2 days ago
    Vector3 m_axis = new Vector3(-1, 0, 0);
    static int frameindex = 0;
    static int objindex = 0;
    static int framewait = 100;
    void Update()
    {
        if (framewait > 0)
        {
            framewait--;
            return;
        }
        if (objindex < m_days.Count + 1)
        {
            if (frameindex < 349)
            {
                m_days[objindex + 1].transform.RotateAround(m_cube.transform.position, m_axis, 1);
                if (frameindex > 340)
                    m_days[objindex].transform.RotateAround(m_cube.transform.position, m_axis, 1);
                frameindex++;
            }
            else
            {
                objindex++;
                frameindex = 0;
            }
        }

    }
}
