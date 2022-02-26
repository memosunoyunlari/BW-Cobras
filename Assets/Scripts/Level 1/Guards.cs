using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Guards : MonoBehaviour
{

    [SerializeField] bool guardOne;
    
    public NavMeshAgent navMeshAgent; 
    
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPos)
    {
        navMeshAgent.SetDestination(targetPos);
        GetComponent<Animator>().SetBool("Guard Ready", false);
    }

    public void ShowIndicator()
    {
        
        GetComponent<Animator>().SetBool("Guard Ready", true);

        //Instantiate accordingly
    }

    public void RemoveIndicator()
    {
        GetComponent<Animator>().SetBool("Guard Ready", false);

        GameObject[] indicatorObjects = GameObject.FindGameObjectsWithTag("Indicator");
        foreach (GameObject indicator in indicatorObjects)
        {
            Destroy(indicator.gameObject);
        }
    }

}
