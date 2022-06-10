using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class VisionSlice : MonoBehaviour
{
	
	public float distance = 10f;
	public float angle = 30;
	public float height = 1.0f;
	public Color line = Color.red;
	public int raycastFreq = 25; //4 times a second
	public LayerMask bodypart;
	public List<GameObject> detections = new List<GameObject>();
	
	Collider[] colliders = new Collider[50];
	Mesh mesh;
	
	int count;
	float scanInterval, scanTimer;
	
    // Start is called before the first frame update
    void Start()
    {
	    scanInterval = 1.0f/ scanTimer;
    }

    // Update is called once per frame
    void Update()
    {
	    scanTimer -= Time.deltaTime;
	    if (scanTimer < 0) {
	    	scanTimer+= scanInterval;
	    	Scan();
	    }
    }
    
	private void Scan() {
		count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, bodypart, QueryTriggerInteraction.Collide);
		
		for (int i = 0; i < count; ++i) {
			GameObject obj = colliders[i].gameObject;
			if (IsOnSight(obj)) { detections.Add(obj); Debug.Log("found something called");}
		}
	}
	
	public bool IsOnSight(GameObject obj) {
		
		return true;
	}
    
	Mesh VisionWedge() {
		Mesh mesh = new Mesh();
		
		int Triangles = 8;
		int Vertices = Triangles * 3;
		
		Vector3[] vert = new Vector3[Vertices]; //
		int[] tri = new int[Vertices];
		
		Vector3 bottom = Vector3.zero;
		Vector3 bleft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
		Vector3 bright = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;
		
		Vector3 top = bottom + Vector3.up * height;
		Vector3 tleft = bleft + Vector3.up * height;
		Vector3 tright = bright + Vector3.up * height;
		
		int v = 0; //
		
		vert[v++] = bottom;
		vert[v++] = top;
		vert[v++] = tright;
		
		vert[v++] = tright;
		vert[v++] = bright;
		vert[v++] = bottom;
		
		vert[v++] = bleft;
		vert[v++] = bright;
		vert[v++] = tright;    //i should comment all of these later so i understand what is going on
		
		vert[v++] = tright;
		vert[v++] = tleft;
		vert[v++] = bleft;
		
		vert[v++] = top;
		vert[v++] = tleft;
		vert[v++] = tright;
		
		vert[v++] = bottom;
		vert[v++] = bright;
		vert[v++] = bleft;
		
		for (int i = 0; i < v; ++i) {
			tri[i] = i;
		}
		
		mesh.vertices = vert;
		mesh.triangles = tri;
		mesh.RecalculateNormals();
		
		
		
		return mesh;
	}
	
	private void OnValidate() {
		mesh = VisionWedge();
	}
	
	private void OnDrawGizmos() {
		if (mesh) {
			Gizmos.color = line;
			Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
		}
	}
	
    
}
