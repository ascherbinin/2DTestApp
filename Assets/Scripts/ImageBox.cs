using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBox : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public int ID { get; set; }

    public Text LblText;

    void Awake ()
    {
        _renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Setup(int id)
    {
        ID = id;
		ImageInfo imgInfo = ImageDictionary.Images [id];
		LblText.text = imgInfo.Text;
		Sprite sprite = Resources.Load (imgInfo.ImagePath, typeof(Sprite)) as Sprite; 
		_renderer.sprite = sprite;
    }
}
