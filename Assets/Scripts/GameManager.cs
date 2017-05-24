﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 1.5f;
    public int numbersOfImage = 7;
    public static GameManager instance = null;             
    public Canvas MenuUI;
    public Canvas GameUI;
    public Canvas TransictionUI;
    public GameObject cube;
    public GameObject image;
    public Text levelText;

    public List<GameObject> imageList = new List<GameObject>();
	public List<GameObject> viewedImages = new List<GameObject>();

    private GameObject currentImage;
    private Vector2 centerPosition = new Vector2(0,0);
    private Vector2 poolPosition = new Vector2(-15, -15);


    void Awake()
	{
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        CreatePoolImage();
    }
		
    public void InitGame()
    {

        levelText.text = "Игра начинается ";
        HideMenu();
        StartCoroutine("HideLevelImage", levelStartDelay);
    }


    //Hides black image used between levels
    void HideMenu()
    {
        cube.SetActive(false);
        MenuUI.enabled = false;
        TransictionUI.gameObject.SetActive(true);
    }

    IEnumerator HideLevelImage(float time)
    {

        yield return new WaitForSeconds(time);
        TransictionUI.gameObject.SetActive(false);
        GameUI.gameObject.SetActive(true);
        StartGame();
    }

    //Update is called every frame.
    void Update()
    {

    }


    void StartGame()
    {
        ChangeImage();
    }

    public void ChangeImage()
    {
		if (currentImage != null)
			currentImage.transform.position = poolPosition;
        int imgIdx = Random.Range(0, imageList.Count - 1);
        Debug.Log("IDX: " + imgIdx);
        currentImage = imageList[imgIdx];
        currentImage.transform.position = centerPosition;
		viewedImages.Add (imageList [imgIdx]);
		imageList.Remove (currentImage);
		if (imageList.Count == 0)
			imageList = viewedImages;
    }

    void CreatePoolImage()
    {
        for (int i = 1; i <= numbersOfImage; i++)
        {
            var imageBox = Instantiate(image, poolPosition, Quaternion.identity);
            imageBox.GetComponent<ImageBox>().Setup(i, "");
            imageList.Add(imageBox);
        }
    }
}
