using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathway : MonoBehaviour
{
	
	public int Point;
	public GameObject location1;
	public GameObject location2;
	public GameObject location3;
	public GameObject location4;
	public GameObject location5;
	public GameObject location6;
	public GameObject location7;
	public GameObject location8;
	public GameObject location9;
	public GameObject location10, location11, location12, location13, location14, location15, location16, location17, location18, location19;
	
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
			if (Point == 18) { Point = 0; this.gameObject.transform.position = new Vector3(location1.transform.position.x, location1.transform.position.y, location1.transform.position.z); }
			if (Point == 17) { Point = 18; this.gameObject.transform.position = new Vector3(location19.transform.position.x, location19.transform.position.y, location19.transform.position.z); }
			if (Point == 16) { Point = 17; this.gameObject.transform.position = new Vector3(location18.transform.position.x, location18.transform.position.y, location18.transform.position.z); }
			if (Point == 15) { Point = 16; this.gameObject.transform.position = new Vector3(location17.transform.position.x, location17.transform.position.y, location17.transform.position.z); }
			if (Point == 14) { Point = 15; this.gameObject.transform.position = new Vector3(location16.transform.position.x, location16.transform.position.y, location16.transform.position.z); }
			if (Point == 13) { Point = 14; this.gameObject.transform.position = new Vector3(location15.transform.position.x, location15.transform.position.y, location15.transform.position.z); }
			if (Point == 12) { Point = 13; this.gameObject.transform.position = new Vector3(location14.transform.position.x, location14.transform.position.y, location14.transform.position.z); }
			if (Point == 11) { Point = 12; this.gameObject.transform.position = new Vector3(location13.transform.position.x, location13.transform.position.y, location13.transform.position.z); }
			if (Point == 10) { Point = 11; this.gameObject.transform.position = new Vector3(location12.transform.position.x, location12.transform.position.y, location12.transform.position.z); }
			if (Point == 9) { Point = 10; this.gameObject.transform.position = new Vector3(location11.transform.position.x, location11.transform.position.y, location11.transform.position.z); }
			if (Point == 8) { Point = 9; this.gameObject.transform.position = new Vector3(location10.transform.position.x, location10.transform.position.y, location10.transform.position.z); }
			if (Point == 7) { Point = 8; this.gameObject.transform.position = new Vector3(location9.transform.position.x, location9.transform.position.y, location9.transform.position.z); }
			if (Point == 6) { Point = 7; this.gameObject.transform.position = new Vector3(location8.transform.position.x, location8.transform.position.y, location8.transform.position.z); }
			if (Point == 5) { Point = 6; this.gameObject.transform.position = new Vector3(location7.transform.position.x, location7.transform.position.y, location7.transform.position.z); }
			if (Point == 4) { Point = 5; this.gameObject.transform.position = new Vector3(location6.transform.position.x, location6.transform.position.y, location6.transform.position.z); }
			if (Point == 3) { Point = 4; this.gameObject.transform.position = new Vector3(location5.transform.position.x, location5.transform.position.y, location5.transform.position.z); }
			if (Point == 2) { Point = 3; this.gameObject.transform.position = new Vector3(location4.transform.position.x, location4.transform.position.y, location4.transform.position.z); }
			if (Point == 1) { Point = 2; this.gameObject.transform.position = new Vector3(location3.transform.position.x, location3.transform.position.y, location3.transform.position.z); }
			if (Point == 0) { Point = 1; this.gameObject.transform.position = new Vector3(location2.transform.position.x, location2.transform.position.y, location2.transform.position.z); }
		
	}
	
	} }


	//6, 1, 40
		
	/*	if (other.tag == "AlSalasel") {
	if (Point == 5) { Point = 0; this.gameObject.transform.position = new Vector3(location1.transform.position.x, location1.transform.position.y, location1.transform.position.z); }
	if (Point == 4) { Point = 5; this.gameObject.transform.position = new Vector3(-2, 1, 68); }
	if (Point == 3) { Point = 4; this.gameObject.transform.position = new Vector3(5, 1, 68); }
	if (Point == 2) { Point = 3; this.gameObject.transform.position = new Vector3(11, 1, 75); }
	if (Point == 1) { Point = 2; this.gameObject.transform.position = new Vector3(10, 1, 58); }
	if (Point == 0) { Point = 1; this.gameObject.transform.position = new Vector3(15, 1, 44); }
	} */
