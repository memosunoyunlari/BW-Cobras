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

    public bool IndicatorIsOn = false;



    private void Awake()
    {
        


    }


    void Update()
    {
        
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && yourTurn)
        {
            castRay();

                switch (target)
                {

                case "Guard":
                    
                    if (IndicatorIsOn == false)
                    {
                        guardScript.ShowIndicator();
                   
                        IndicatorIsOn = true;
                    }
                    else break;

                    break;

                case "Board":

                    guardScript.Move(targetPos);
                    yourTurn = false;
                    guardScript.RemoveIndicator();
                   
                    break;

                case "Something Else":

                    if (IndicatorIsOn == true)
                    {
                        guardScript.RemoveIndicator();
                        IndicatorIsOn = false;
                        
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
            targetPos = new Vector3(
                Mathf.Round(guardRayHit.collider.gameObject.transform.position.x), 
                Mathf.Round(guardRayHit.collider.gameObject.transform.position.y), 
                Mathf.Round(guardRayHit.collider.gameObject.transform.position.z));
            Debug.Log(targetPos);

        }
        else target = "Something Else";

        

        return target;
    }
}
