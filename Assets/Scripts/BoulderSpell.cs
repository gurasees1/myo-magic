using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpell : MonoBehaviour {

    public int z_direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * 25 * z_direction);
    }
}
