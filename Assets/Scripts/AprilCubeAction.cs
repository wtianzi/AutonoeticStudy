using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AprilCubeAction : MonoBehaviour {

    // Use this for initialization
    public DaysFlyCanvas m_rotationmarkerobj;
    public float smooth = 2.0F;
    public float tiltAngle = 90.0F;

    // Update is called once per frame
    void Update () {
        if(m_rotationmarkerobj!=null)
        {
            if(m_rotationmarkerobj.rotationmark)
            {
                //rotation
                //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
                //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAngle, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                m_rotationmarkerobj.rotationmark = false;
            }
            
        }
    }
}




