using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCircle : MonoBehaviour
{
	
	public float radius;
	[Range(0,360)]
	public float angle;
	
	public GameObject player;
	
	public LayerMask target;
	public LayerMask blockade;
	
	public bool found;
	
    // Start is called before the first frame update
    void Start()
    {
	    player = GameObject.FindGameObjectWithTag("Player");
	    StartCoroutine(FOVRoutine());
    }
    
	private IEnumerator FOVRoutine() {
		
		float delay = 0.1f;
		WaitForSeconds wait = new WaitForSeconds(delay);
		
		while (true) {
			yield return wait;
			FieldOfViewCheck();
		}
		
		
	}
	
	private void FieldOfViewCheck() {
		Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, target);
		
		if (rangeCheck.Length != 0) {
			Transform t = rangeCheck[0].transform;
			Vector3 direction = (t.position - transform.position).normalized;
			
			if(Vector3.Angle(transform.forward, direction) < angle / 2) {
				float distance = Vector3.Distance(transform.position, t.position);
				
				if (!Physics.Raycast(transform.position, direction, distance, blockade)) {
					found = true;
				}
				else found = false;
			}
			else found = false;
		}
		else if (found) found = false;
	}

}
