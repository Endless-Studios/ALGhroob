using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
	public Transform target1;
	public Transform target2;
	public NavMeshAgent agent;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
    	
	    agent.SetDestination(target1.position);
		
	 
	    
	    
	    
    }
}
