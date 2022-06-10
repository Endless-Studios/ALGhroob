using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentScript : MonoBehaviour
{
	
	float scentTimer = 0f;
	float duration = 10f;
	float scentStrength = 10f;
	Vector3 scaleChange = new Vector3(2f, 2f, 2f);
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    scentTimer += 1 * Time.deltaTime;
	    scentStrength -= 1 * Time.deltaTime;
	    if(scentTimer >= duration) Destroy(gameObject);
    }

	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "Player") {
			gameObject.transform.localScale += scaleChange * Time.deltaTime;
		}
		
	
		
	}

	void OnTriggerStay(Collider other) {
		
		if (other.tag == "Player") {
			gameObject.transform.localScale += scaleChange * Time.deltaTime;
		}
		
	}

}
