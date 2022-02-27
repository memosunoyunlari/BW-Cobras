using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Guards : MonoBehaviour
{

    [SerializeField] bool guardOne;

    [SerializeField] GameObject longIndicator;
    [SerializeField] GameObject shortIndicator;
    [SerializeField] GameObject longAttackIndicator;
    
    private NavMeshAgent navMeshAgent;

    private Vector3[] indicatorDirections;
    private Vector3[] longIndicatorPosOffsets;
    private Vector3[] shortIndicatorPosOffsets;
    private Quaternion[] indicatorRotations;

    [SerializeField] LayerMask endLayer;
    private RaycastHit endHit;


    

    private void Update()
    {
       
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        indicatorDirections = new[] { -Vector3.forward, -Vector3.right, Vector3.forward, Vector3.right };
        longIndicatorPosOffsets = new[] { new Vector3(0, 0, -8), new Vector3(-8, 0, 0), new Vector3(0, 0, 8), new Vector3(8, 0, 0) };
        shortIndicatorPosOffsets = new[] { new Vector3(0,0,-4), new Vector3(-4, 0, 0), new Vector3(0, 0, 4), new Vector3(4, 0, 0) };
        indicatorRotations = new[] { Quaternion.Euler(0, -180, 0), Quaternion.Euler(0, -90, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 90, 0) };


    }

    public void Move(Vector3 targetPos)
    {
        navMeshAgent.SetDestination(targetPos);
        GetComponent<Animator>().SetBool("Guard Ready", false);
    }

    public void ShowIndicator()
    {
        
        

        for (int i = 0; i < 4; i++)
        {
            

            if (!Physics.Raycast(transform.position + new Vector3(0,1,0), indicatorDirections[i], out endHit, 8, endLayer))
            {
                Instantiate(longIndicator, transform.position + longIndicatorPosOffsets[i], indicatorRotations[i]);
                //Debug.DrawRay(transform.position + new Vector3(0, 2, 0), indicatorDirections[i] * 8, Color.red, 5);

            }

            else if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), indicatorDirections[i], out endHit, 8, endLayer))
            {
                if (Vector3.Distance(transform.position, endHit.transform.position) < 5)
                {
                    Instantiate(longAttackIndicator, transform.position + longIndicatorPosOffsets[i], indicatorRotations[i]);
                }
                else if(Vector3.Distance(transform.position, endHit.transform.position) > 5)
                {
                    Instantiate(shortIndicator, transform.position + shortIndicatorPosOffsets[i], indicatorRotations[i]);
                }
            }


        }

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
