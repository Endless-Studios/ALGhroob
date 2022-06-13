using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathAudio : MonoBehaviour
{
	
	public int Point;
	public GameObject location1;
	public GameObject location2;
	public GameObject location3;
	public GameObject location4;
	
	
    // Start is called before the first frame update
    void Start()
    {
	    Point = 0;
    }

    // Update is called once per frame
    void Update()
    {
		
    }
    
	void OnTriggerEnter(Collider other) {
		
		
		
		if (other.tag == "AlSalasel") {
			if (Point == 0) { Point = 1; this.gameObject.transform.position = new Vector3(location1.transform.position.x, location1.transform.position.y, location1.transform.position.z); }
			else if (Point == 1) { Point = 2; this.gameObject.transform.position = new Vector3(location2.transform.position.x, location2.transform.position.y, location2.transform.position.z); }
			else if (Point == 2) { Point = 3; this.gameObject.transform.position = new Vector3(location3.transform.position.x, location3.transform.position.y, location3.transform.position.z); }
			else if (Point == 3) { Point = 0; this.gameObject.transform.position = new Vector3(location4.transform.position.x, location4.transform.position.y, location4.transform.position.z); }
		
		}
	
	} 
}



