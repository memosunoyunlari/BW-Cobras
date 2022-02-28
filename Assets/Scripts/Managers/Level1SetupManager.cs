using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SetupManager : MonoBehaviour
{
    [SerializeField] GameObject doorR;
    [SerializeField] GameObject doorL;

    [SerializeField] float doorDelay;
    [SerializeField] float doorPeriod;

    private void Start()
    {

        StartCoroutine(Setup());


    }

    IEnumerator Setup()
    {
        yield return new WaitForSeconds(doorDelay);

        var startTime = Time.time;

        var startL = doorL.transform.rotation;
        var startR = doorR.transform.rotation;

        var endL = Quaternion.Euler(-90, 0, -90);
        var endR = Quaternion.Euler(-90, 0, 90);

        while (Time.time < startTime + doorPeriod)
        {
            doorL.transform.rotation = Quaternion.Lerp(startL, endL, (Time.time - startTime) / doorPeriod);
            doorR.transform.rotation = Quaternion.Lerp(startR, endR, (Time.time - startTime) / doorPeriod);

            yield return null;
        }
    }
}
