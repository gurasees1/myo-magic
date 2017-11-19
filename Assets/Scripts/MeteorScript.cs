using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {

    public float x_direction;
    public float y_direction;
    public float z_direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(x_direction, y_direction, z_direction) * Time.deltaTime * 25;
    }
}
