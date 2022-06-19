using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AudioEnemyPath : MonoBehaviour
{
	
	public GameObject pathway;
	NavMeshAgent enemy;
	public GameObject thePlayer;
	public SoundCalculation sound;
	public bool enemyTriggered;
	public int timer =10;

	
	
	// Start is called before the first frame update
	void Start()
	{
		enemy = GetComponent<NavMeshAgent>();
		enemy.SetDestination(pathway.transform.position);
		enemyTriggered=false;
	    
	}

	// Update is called once per frame
	void Update()
	{
		
		
		
		
		
		if(sound.soundEmitted>3){
			enemyTriggered=true;
			
		}
		
		if(enemyTriggered){
			if(timer>0){
				timer-=1;
				enemy.SetDestination(thePlayer.transform.position);
			}
			else{
				timer=10;
				enemyTriggered=false;
			}
			
		}
		else{
			enemy.SetDestination(pathway.transform.position);
		}
		
		
		
	}
    
	
    
}
