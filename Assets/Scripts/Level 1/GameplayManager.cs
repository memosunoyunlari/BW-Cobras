using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private bool yourTurn = true;

    private Ray guardRay;
    private RaycastHit guardRayHit;
    [SerializeField] LayerMask guardMask;
    [SerializeField] LayerMask boardMask;
    private string target;

    private Vector3 targetPos;

    private Guards guardScript;

    private bool Indicator;


    private void Awake()
    {
        


    }


    void Update()
    {
        
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && yourTurn)
        {
            castRay();
            

            if (Physics.Raycast(guardRay, 100, boardMask))
            {
                Debug.Log("wow");
            }

                switch (target)
            {

                case "Guard":
                    
                    if (Indicator == false)
                    {
                        guardScript.guardType.ShowIndicator();
                   
                        Indicator = true;
                    }
                    else break;

                    break;

                case "Board":

                    guardScript.guardType.Move(targetPos);
                    yourTurn = false;
                    guardScript.guardType.RemoveIndicator();
                   
                    break;

                case "Something Else":

                    if (Indicator)
                    {
                        Indicator = false;
                        guardScript.guardType.RemoveIndicator();
                        GameObject[] indicatorObjects = GameObject.FindGameObjectsWithTag("Indicator");
                        foreach (GameObject indicator in indicatorObjects)
                        {
                            Destroy(indicator.gameObject);
                        }
                    }
                    
                    break;

                    
            
            
            
            
            
            
            }
        }
    }

    public string castRay()
    {
        guardRay = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(guardRay, out guardRayHit, 60, guardMask))
        {
            target = "Guard";
            guardScript = guardRayHit.collider.gameObject.GetComponent<Guards>(); 

        }
        else if (Physics.Raycast(guardRay, out guardRayHit, 60, boardMask))
        {
            target = "Board";
            targetPos = guardRayHit.collider.gameObject.transform.position;
            Debug.Log(target);

        }
        else target = "Something Else";

        

        return target;
    }
}
