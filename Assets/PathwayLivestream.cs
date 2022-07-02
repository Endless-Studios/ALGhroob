using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathwayLivestream : MonoBehaviour
{
	
	public int increment;
	public GameObject location1;
	public GameObject location2;
	
    // Start is called before the first frame update
    void Start()
    {
        
	    increment = 0;
    }

    // Update is called once per frame
    void Update()
    {
	    
    }
    
	void OnTriggerEnter(Collider Other) {
		
		if (Other.tag == "Enemy") {
		if (increment == 1) { increment = 2; this.gameObject.transform.position = new Vector3(location2.transform.position.x, location2.transform.position.y, location2.transform.position.z); }
		if (increment == 0) { increment = 1; this.gameObject.transform.position = new Vector3(location1.transform.position.x, location1.transform.position.y, location1.transform.position.z); }
		}
		
	}
	
    
}
