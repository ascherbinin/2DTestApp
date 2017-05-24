using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBox : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public int ID { get; set; }

    public Text LblText;

    private string[] msgs = new string[] { "opa opa opa", "param pram pam", "kis kis kis krya", "opa pacanchik na prikole", "opa pacanchik na prikole opa pacanchik na prikole \n opa pacanchik na prikole" };

    void Start ()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0F, 1.0F), Random.Range(0.0F, 1.0F), Random.Range(0.0F, 1.0F));
        _renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setup(int id, string text)
    {
        ID = id;
		LblText.text = id.ToString();
    }
}
