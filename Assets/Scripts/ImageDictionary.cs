using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageDictionary
{
	public static Dictionary<int, ImageInfo> Images = new Dictionary<int, ImageInfo> {
		{ 1, new ImageInfo ("Красная защитная каска", "icon_1") },
		{ 2, new ImageInfo ("Мощнейшая зубодробительная кирка", "icon_2") },
		{ 3, new ImageInfo ("Просто хозяин гор", "icon_3") },
		{ 4, new ImageInfo ("Боты-ледоступы, боты-горнолазы", "icon_4") },
		{ 5, new ImageInfo ("Кошка которая не мяукает", "icon_5") },
		{ 6, new ImageInfo ("Последние пристанище путешественника", "icon_6") },
		{ 7, new ImageInfo ("Последний йети на земле", "icon_7") }
	};

}
