using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCalculation : MonoBehaviour
{

	public float noiseLevel;
	public float soundEmitted=0;
	
	public CheckGround grass;
	public CheckGround wood;
	
	public PlayerMovement player;
	public GameObject enemy;
    public AudioSource beep;
	
	public float sound = 1;
	public float crouching = 2;
	public float walking =4;
	public float sprinting =6;
	
	public float grassMult=2;
	public float woodMult=3;
    
    public int beepCount;
	
	float distance;
	
	
    // Start is called before the first frame update
    void Start()
    {
	    sound=1;
        beepCount=0;
    }

    // Update is called once per frame
    void Update()
	{
		distance = Vector3.Distance (player.transform.position, enemy.transform.position);
		
		if(player.isWalking){
			sound=walking;
			if(player.isCrouching){
				sound=crouching;
			}
		}
		
		if(!player.isWalking){
			sound=1;
		}
		
		if(player.isSprinting){
			sound=sprinting;
		}
		
		if(grass.isOnGround){
			noiseLevel=sound*grassMult;
		}
		else if(wood.isOnGround){
			noiseLevel=sound*woodMult;
		}
		else{
			noiseLevel=sound;
		}
		
		soundEmitted=calcSoundEmitted();
		Debug.Log(distance);
        
        if(!beep.isPlaying)
        {
            if(distance<2){
                beep.Play();
                beepCount+=1;
            }
        }
        
        else
        {
            
        
        }
        
                
	}
    
	float calcSoundEmitted(){
		return noiseLevel/(distance/2);
	}
}
