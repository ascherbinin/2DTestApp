using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 dir = new Vector3(0, 1, 0);
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(dir, Speed * Time.deltaTime);
	}
}
