using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySniff : MonoBehaviour
{
	
	public GameObject scent;
	
	public GameObject path;
	
	NavMeshAgent enemy;
	public GameObject player;
	public bool sniffed;
	public bool found;
	
    // Start is called before the first frame update
    void Start()
	{
		enemy = GetComponent<NavMeshAgent>();
	    sniffed = false;
		found = false;
		enemy.SetDestination(path.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Scent") {
	
			enemy.SetDestination(other.transform.position);
			
	}
		
	}
	
	void OnTriggerStay(Collider other) {
		
		//if (other.tag == "Scent") {
	
		
		//}
		
	}
	
	void OnTriggerExit(Collider other) {
		
		
		// if (other.tag == "Player") {
		//enemy.setdfafa
		//}
		
	} 
    
}
