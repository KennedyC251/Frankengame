using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    // event -  if nothing is subscribed to it when you call it, you'll get a null error
    public static event Action TimesUp;

    public float countdownEverySeconds;
    public float counter;

    void Start()
    {
        // init the counter
        counter = countdownEverySeconds;
    }

    void Update()
    {
        // if countdown is up
        if (counter < 0)
        {
            // make sure something is subscribed before invoking (calling all functions)
            //if (TimesUp != null) TimesUp.Invoke();
            if (TimesUp != null) TimesUp();
            counter = countdownEverySeconds;
        }

        // update width
        float percentDone = counter / countdownEverySeconds;
        transform.localScale = new Vector2(percentDone, 1f);

        // update counter 
        counter -= Time.deltaTime;
    }
}
