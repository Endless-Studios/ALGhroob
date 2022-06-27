using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
	
	public GameObject destination1;

	NavMeshAgent enemy;
	public static bool canSpin;
	public GameObject thePlayer;
	public bool on = false;
	public bool found;
	public AudioSource chaser;
	public bool isPlaying = false;
	
    // Start is called before the first frame update
    void Start()
    {
	    enemy = GetComponent<NavMeshAgent>();
	    enemy.SetDestination(destination1.transform.position);
	    chaser.Stop();
	    
	    
    }

    // Update is called once per frame
    void Update()
	{
		
		found = VisionSlice.found;
		//enemy.SetDestination(destination1.transform.position);
		
		
		
		if (Input.GetMouseButtonDown(1))
		{
			if(!on)
			{
				
				on = true;
			}
			else
			{
				
				on = false;
	    		
			}
		}
		
		if (found) {
			enemy.SetDestination(thePlayer.transform.position);
			enemy.speed = 4.5f;
			if (!isPlaying) { chaser.Play(); isPlaying = true; }
		}
		else {
			enemy.SetDestination(destination1.transform.position);
		}
		
		
	    
	    //if player is close rotate else continue
        
		
	}
    
	/*	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
		if(on)
		{
			found = true;
			enemy.SetDestination(thePlayer.transform.position);
		}
		else {
			enemy.SetDestination(destination1.transform.position);
		}
			
			}
		
	}
	
	void OnTriggerStay(Collider other) {
		
		if (other.tag == "Player") {
		if(on)
		{
			found = true;
			enemy.SetDestination(thePlayer.transform.position);
			}
		
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		
		
		//enemy.SetDestination(destination1.transform.position);
		
		
	} */
    
}
