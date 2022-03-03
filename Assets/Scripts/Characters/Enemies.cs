using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    [SerializeField] int moveRange; 


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move()
    {
        Vector3 targetPos = transform.position + Vector3.right * moveRange;

        navMeshAgent.SetDestination(targetPos);
    }

    public void ReadyAnimation(string readiness)
    {
        switch (readiness)
        {
            case "true":
                GetComponent<Animator>().SetBool("Guard Ready", true);
                break;
            case "false":
                GetComponent<Animator>().SetBool("Guard Ready", false);
                break;
        }
    }
}
