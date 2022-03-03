using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SetupManager : MonoBehaviour
{
    [Header("Level 1 Variables")]

    [SerializeField] bool levelOneSetup;

    [SerializeField] GameObject doorR;
    [SerializeField] GameObject doorL;

    [SerializeField] float doorDelay;
    [SerializeField] float doorPeriod;

    [SerializeField] GameObject[] enemies;

    [SerializeField] Vector3[] enemyStartingPositions;

    [SerializeField] float tutorialPanelDelay;

    [SerializeField] float firstEnemyMoveDelay;

    private void Awake()
    {
        
    }

    private void Start()
    {

        if(levelOneSetup) StartCoroutine(Level1Setup());
        

    }

    IEnumerator Level1Setup()
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



        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameObject.GetComponent<NavMeshAgent>().speed = 8;
            enemies[i].gameObject.GetComponent<NavMeshAgent>().SetDestination(enemyStartingPositions[i]);
        }

        //onlar�n y�n�n� �evir ve indikat�rlerini g�ster ve bir s�re sonra da tutorial ekran�n� ��kar ve orada da butonla onlar� ileri g�t�r sonra da guard'a ait bilgiyi i�erecek paneli ��kar ve yourTurn bool'unu buton ile de�i�tir.

        
        

    }
}
