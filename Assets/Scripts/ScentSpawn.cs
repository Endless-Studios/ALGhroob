using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentSpawn : MonoBehaviour
{
	
	public GameObject scent;
	public Transform player;
	
	float spawnTimer = 0f;
	float duration = 1f;
	
	//Vector3 location = player.transform;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
	    spawnTimer += 1 * Time.deltaTime;
	        if (spawnTimer >= duration) { spawnTimer = 0;
		        Instantiate(scent, player.position, Quaternion.identity);}
    }
}
