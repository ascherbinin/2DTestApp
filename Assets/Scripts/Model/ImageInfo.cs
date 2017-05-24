using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageInfo
{
	public string Text { get; set; }
	public string ImagePath { get; set; }

	public ImageInfo(string text, string imageName)
	{
		Text = text;
		ImagePath = "Images/" + imageName;
	}


}
