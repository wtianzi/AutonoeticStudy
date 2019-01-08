using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	//-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
	public int seconds = 0;
	public bool realTime=true;
	
	public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    public GameObject daypast;
    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs=0;
    private static int times = 24;//hours

    private static int latetime = 200;
void Start() 
{
	//-- set real time
	if (realTime)
	{
		hour=System.DateTime.Now.Hour;
		minutes=System.DateTime.Now.Minute;
		seconds=System.DateTime.Now.Second;
            float rotationSeconds = (360.0f / 60.0f) * seconds;
            float rotationMinutes = (360.0f / 60.0f) * minutes;
            float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

            //-- draw pointers
            pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
            pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
            pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
        }
}

void Update() 
{
    //-- calculate time
    if(latetime>0)
        {
            latetime--;
            return;
        }

    if(times > 0)
        {
            pointerSeconds.SetActive(false);
            minutes = minutes - (int)clockSpeed;
            if (minutes < 0 )
            {
                hour = hour - 1;
                minutes = 59;
                times--;
                if(hour==0)
                {
                    daypast.SetActive(false);
                }
            }
        }
        else if (times == 0)
        {
            hour = System.DateTime.Now.Hour;            
            minutes = minutes - 1;
            if(minutes == System.DateTime.Now.Minute)
            {
                pointerSeconds.SetActive(true);
                times = -1;
                seconds = System.DateTime.Now.Second;
                
            }
        }
    else
        {
            msecs += Time.deltaTime * clockSpeed;
            //seconds = seconds - 1;
            if (msecs >= 1.0f)
            {
                msecs -= 1.0f;
                seconds++;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                    if (minutes > 60)
                    {
                        minutes = 0;
                        hour++;
                        if (hour >= 24)
                            hour = 0;
                    }
                }
            }
        }
   
        
               
             

        //-- calculate pointer angles
    float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

}
}
