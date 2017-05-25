using System.Collections;
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
    private bool isLoaded = false;
    private bool isBacked = false;

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
        var gi = SaveLoadManager.Load();
        if (gi != null)
        {
            isLoaded = true;
            var imgID = -1;
            if (isBacked)
                imgID = gi.idImage;
            else
                imgID = gi.idImage - 1;
            currentImage = imageList[imgID];
            ScoreManager.instance.LeftCnt = gi.leftCnt;
            ScoreManager.instance.RightCnt = gi.rightCnt;
        }
        ChangeImage();
    }

    public void ChangeImage()
    {
        if (isLoaded)
        {
            currentImage.transform.position = centerPosition;
            isLoaded = false;
            isBacked = false;
        }
        else
        {
            if (imageList.Count == 0 && viewedImages.Count != 0)
            {
                imageList.AddRange(viewedImages);
                viewedImages.Clear();
            }

            if (currentImage != null)
                currentImage.transform.position = poolPosition;

            var imgIdx = Random.Range(0, imageList.Count);

            currentImage = imageList[imgIdx];
            currentImage.transform.position = centerPosition;
        }
        viewedImages.Add (currentImage);
		imageList.Remove (currentImage);

        SaveLoadManager.Save(currentImage.GetComponent<ImageBox>().ID, ScoreManager.instance.LeftCnt, ScoreManager.instance.RightCnt);
    }

    void CreatePoolImage()
    {
        var go = new GameObject();
        go.name = "ImagesPool";
        for (int i = 1; i <= numbersOfImage; i++)
        {
            var imageBox = Instantiate(image, poolPosition, Quaternion.identity);
            imageBox.GetComponent<ImageBox>().Setup(i);
            imageList.Add(imageBox);
            imageBox.transform.parent = go.transform;
        }
    }

	public void BackToMenu()
	{
		HideGame ();
		currentImage.transform.position = poolPosition;
		imageList.AddRange (viewedImages);
		//imageList.Clear ();
		viewedImages.Clear ();
        isBacked = true;
	}

	void HideGame()
	{
		GameUI.gameObject.SetActive(false);
		cube.SetActive(true);
		MenuUI.enabled = true;

	}
}
