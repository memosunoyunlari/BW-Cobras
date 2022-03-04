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
            enemies[i].gameObject.GetComponent<NavMeshAgent>().speed = 9;
            enemies[i].gameObject.GetComponent<NavMeshAgent>().SetDestination(enemyStartingPositions[i]);
            enemies[i].gameObject.GetComponent<Enemies>().setRotation = false;
        }

        yield return new WaitForSeconds(6.5f);

        //set their rotation values so that they are on the direction

        for (int i = 0; i < enemies.Length; i++)
        {

            StartCoroutine(SetRotation(enemies[i],1));
            
        }

        yield return new WaitForSeconds(1);

        //indikatörlerini göster ve bir süre sonra da tutorial ekranýný çýkar ve orada da butonla onlarý ileri götür sonra da guard'a ait bilgiyi içerecek paneli çýkar ve yourTurn bool'unu buton ile deðiþtir.

        
        

    }

    IEnumerator SetRotation(GameObject enemy, float timeInterval)
    {
        float currentTime = Time.time;
        

        Quaternion targetRotation = Quaternion.Euler(enemy.transform.rotation.x, 90, enemy.transform.rotation.z);

        while (Time.time < currentTime + timeInterval)
        {
            enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, targetRotation, 10 * Time.deltaTime);
            yield return null;
        }

        
    }

}
