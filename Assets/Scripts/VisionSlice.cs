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
	public LayerMask blockades;
	public List<GameObject> detections = new List<GameObject>();
	
	public static bool found = false;
	
	Collider[] colliders = new Collider[50];
	Mesh mesh;
	
	int count;
	float scanInterval, scanTimer;
	
    // Start is called before the first frame update
    void Start()
    {
	    scanInterval = 1.0f/ raycastFreq;
    }

    // Update is called once per frame
    void Update()
    {
	    scanTimer -= Time.deltaTime;
	    if (scanTimer < 0) {
	    	scanTimer+= scanInterval;
	    	Scan();
	    }
	    
	    if (Input.GetMouseButtonDown(1)) {
	    	distance = 20f;
	    	angle = 60;
	    	Debug.Log("FlashLight on");
	    }
	    
	    else {
		    distance = 10f;
		    angle = 35;
	    }
    }
    
	private void Scan() {
		count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, bodypart, QueryTriggerInteraction.Collide);
		
		detections.Clear();
		for (int i = 0; i < count; ++i) {
			GameObject obj = colliders[i].gameObject;
			if (IsOnSight(obj)) { detections.Add(obj); Debug.Log("found something called");}
		}
		
		if (detections.Count > 4) {
			found = true;
		}
		
	}
	
	public bool IsOnSight(GameObject obj) {
		
		Vector3 origin = transform.position;
		Vector3 dest = obj.transform.position;
		Vector3 direction = dest - origin;
		
		if (direction.y < 0 || direction.y > height) {
			return false;
		}
		
		direction.y = 0;
		
		float deltaAngle = Vector3.Angle(direction, transform.forward);
		if (deltaAngle > angle) return false;
		
		origin.y += height/2;
		dest.y = origin.y;
		if (Physics.Linecast(origin, dest, blockades)) return false;
		
		return true;
	}
    
	Mesh VisionWedge() {
		Mesh mesh = new Mesh();
		
		int segments = 10;
		int Triangles = (segments * 4) + 2 + 2;
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
		vert[v++] = bleft;
		vert[v++] = tleft;
		
		vert[v++] = tleft;
		vert[v++] = top;
		vert[v++] = bottom;
		
		vert[v++] = bottom;
		vert[v++] = top;
		vert[v++] = tright;    
		
		vert[v++] = tright;
		vert[v++] = bright;
		vert[v++] = bottom;
		
		float currentAngle = -angle;
		float deltaAngle = (angle * 2) / segments;
		for (int i = 0; i < segments; ++i) {

			bleft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
			bright = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * distance;
		
			tleft = bleft + Vector3.up * height;
			tright = bright + Vector3.up * height;
			
			vert[v++] = bleft;
			vert[v++] = bright;
			vert[v++] = tright; //each one represents a triangle
		
			vert[v++] = tright;
			vert[v++] = tleft;
			vert[v++] = bleft;
		
			vert[v++] = top;
			vert[v++] = tleft;
			vert[v++] = tright;
		
			vert[v++] = bottom;
			vert[v++] = bright;
			vert[v++] = bleft;
		
			
			currentAngle += deltaAngle;
		}
		
		
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
		scanInterval = 1.0f/ scanTimer;
	}
	
	private void OnDrawGizmos() {
		if (mesh) {
			Gizmos.color = line;
			Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
		}
		
		Gizmos.DrawWireSphere(transform.position, distance);
		for (int i = 0 ; i < count; ++i) {
			Gizmos.DrawSphere(colliders[i].transform.position, 0.1f);
		}
		
		//foreach (var obj in Object)
	}
	
    
}
