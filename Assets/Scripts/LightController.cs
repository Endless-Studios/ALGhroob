using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
	
	public RenderTexture LightChecker;
	public float LightLevel;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    RenderTexture tempTex = RenderTexture.GetTemporary(LightChecker.width, LightChecker.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
	    Graphics.Blit(LightChecker, tempTex);
	    RenderTexture prev = RenderTexture.active;
	    RenderTexture.active = tempTex;
	    
	    Texture2D temp2DTex = new Texture2D(LightChecker.width, LightChecker.height);
	    temp2DTex.ReadPixels(new Rect(0, 0, tempTex.width, tempTex.height), 0, 0);
	    temp2DTex.Apply();
	    
	    RenderTexture.active = prev;
	    RenderTexture.ReleaseTemporary(tempTex);
	    
	    Color32[] colors = temp2DTex.GetPixels32();
	    
	    LightLevel = 0;
	    
	    for (int i = 0; i < colors.Length; i++) {
	    	LightLevel += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f * colors[i].b);
	    }
	    
	    Debug.Log(LightLevel);
	    
    }
}
