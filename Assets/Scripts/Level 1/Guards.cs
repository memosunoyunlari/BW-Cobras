using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Guard
{
    public abstract void Move(Vector3 targetPos);

    public abstract void ShowIndicator();

    public abstract void RemoveIndicator();

}

public class BasicGuard : Guard
{
    [SerializeField] NavMeshAgent navMeshAgent;

    public override void Move(Vector3 targetPos)
    {

        Debug.Log(targetPos);
    }

    public override void ShowIndicator()
    {
        Debug.Log("Indicators are on");
    }

    public override void RemoveIndicator()
    {
        Debug.Log("Indicators are off");
    }

}
public class Guards : MonoBehaviour
{

    [SerializeField] bool guardOne;
    public Guard guardType;
    

    private void Start()
    {
        if(guardOne)
        {
            guardType = new BasicGuard();
        }
    }

}
