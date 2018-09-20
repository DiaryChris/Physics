using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeDropping : MonoBehaviour {

    private Transform sphere;
    private Transform plane;
    private Mesh mesh;

    public float g;
    private float v;
    private float s;
    private float planeY;
    private float radius;

    // Use this for initialization
    void Start () {
        sphere = GetComponent<Transform>();
        plane = GameObject.Find("Plane").GetComponent<Transform>();
        v = 0;
        s = sphere.position.y;
        planeY = plane.position.y;
        //计算球体半径
        mesh = GetComponent<MeshFilter>().mesh;
        radius = mesh.vertices[0].magnitude;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (sphere.position.y - radius <= planeY)
        {
            v = -v;
        }
        s += v * Time.deltaTime + 0.5f * -g * Time.deltaTime * Time.deltaTime;
        v += -g * Time.deltaTime;
        sphere.position = new Vector3(sphere.position.x, s, sphere.position.z);
    }
    
}
