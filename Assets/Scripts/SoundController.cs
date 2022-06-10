using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
	
	public AudioSource ambience;
	public AudioSource half;
	bool playOnce = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (!playOnce) {ambience.Play(); playOnce = true;}
    }
    
	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
			 half.Play();
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		
		if (other.tag == "Player") {
			half.Stop(); 
		}
	}
}
