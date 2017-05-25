using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImageInfo
{
    public int ID { get; set; }
	public string Text { get; set; }
	public string ImagePath { get; set; }

	public ImageInfo(string text, string imageName)
	{
        Text = text;
		ImagePath = "Images/" + imageName;
	}

    public ImageInfo()
    {
        Text = "";
        ImagePath = "";
        ID = -1;
    }


}
