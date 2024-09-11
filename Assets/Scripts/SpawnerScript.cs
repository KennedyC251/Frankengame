using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject pop;

    // Update is called once per frame
    void Update()
    {
 
    }
    void OnEnable()
    {
        Countdown.TimesUp += Pop; // register for jump event
    }

    void OnDisable()
    {
        Countdown.TimesUp -= Pop; // deregister for jump event
    }

    // called from Countdown (when TimesUp is called)
    void Pop()
    {
        Instantiate(pop, transform.position, transform.rotation);
        Instantiate(pop, transform.position, transform.rotation);
        Instantiate(pop, transform.position, transform.rotation);
        Instantiate(pop, transform.position, transform.rotation);
        Instantiate(pop, transform.position, transform.rotation);
    }
}
