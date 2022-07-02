using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyLivestream : MonoBehaviour
{
	public NavMeshAgent enemy;
	
	public GameObject ThePlayer;
	public GameObject Pathway;
	public bool chase;
	
	
    // Start is called before the first frame update
    void Start()
	{
		enemy = GetComponent<NavMeshAgent>();
		chase = false;
		enemy.SetDestination(Pathway.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
