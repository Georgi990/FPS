using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static float time;
    public static float getTime;
    //bool timesUp;


    void Start () {
		
	}
	
	void Update () {

        if (Target.killedTargets >= 1 && Target.killedTargets < 7)
        {
            //TimerStart();
            time += Time.deltaTime;
            Debug.Log(time);
        }
        else if (Target.killedTargets == 7)
        {
            getTime = time;
            Debug.Log(getTime);
        }

        

        //if (OnScreen.allTargetsDown)
        //{
        //    timesUp = true;
        //}

        //if (timesUp == true)
        //{
        //    getTime = time;
        //    Debug.Log("time's up" + getTime.ToString());
        //}

    }

    void TimerStart()
    {
        time = Time.deltaTime;
    }

}
