using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    
    public Color endColor;
    public bool withLerping = false;
    private Color lerpedColor = Color.white;
    private Color startColor;
    // Use this for initialization
    void Start ()
    {
        startColor = gameObject.GetComponent<MeshRenderer>().material.color;
	}

	// Update is called once per frame
	void Update () {
        if (withLerping)
        {
            lerpedColor = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 2));
            gameObject.GetComponent<MeshRenderer>().material.color = lerpedColor;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        GameManager.instance.InitGame();
    }
}
