using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
	
	
	public bool isOnGround= false;
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Debug.Log("On Trigger Enter");
			isOnGround=true;
		}
	}
    
	void OnTriggerStay(Collider other){
		if(other.tag=="Player"){
			Debug.Log("On Trigger Stay");
			isOnGround=true;
		}
		
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag=="Player"){
			Debug.Log("On Trigger Exit");
			isOnGround=false;
		}
	}
	
}
