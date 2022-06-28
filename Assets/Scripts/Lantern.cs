using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
	[SerializeField] GameObject LanternLight;
	public bool on=false;
	
	
    // Start is called before the first frame update
    void Start()
    {
	    LanternLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.L))
	    {
	    	if(!on)
	    	{
	    		LanternLight.gameObject.SetActive(true);
	    		on = true;
	    	}
	    	else
	    	{
	    		LanternLight.gameObject.SetActive(false);
	    		on = false;
	    		
	    	}
	    }
	    
    }
}
