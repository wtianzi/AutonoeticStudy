using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apirl_back : MonoBehaviour {

    // Use this for initialization
    public GameObject m_cube;
    public DaysFlyCanvas_back m_rotationmarkerobj;
    Vector3 m_axis =new Vector3(1, 0, 0);
    static int degreeacumulate = 1;
    //Vector3 t_v = new Vector3(0, 0, 0);
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update () {        

        if (m_rotationmarkerobj!=null)
        {
            if(m_rotationmarkerobj.rotationmark)
            {
                transform.RotateAround(m_cube.transform.position, m_axis, -4F);//100*Time.deltaTime
                //Quaternion target = Quaternion.Euler(tiltAngle, 0, 0);
                //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                degreeacumulate+=4;
                if (degreeacumulate > 350)
                {
                    degreeacumulate = 0;
                    m_rotationmarkerobj.rotationmark = false;
                }
            }
            
        }
        
    }
}




