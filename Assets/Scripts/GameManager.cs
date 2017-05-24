using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public Canvas MenuUI;
    public Canvas GameUI;
    public Canvas TransictionUI;
    public GameObject cube;
    public GameObject image;
    public Text levelText;                                 

 
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        //InitGame();
    }


    //Initializes the game for each level.
    public void InitGame()
    {

        levelText.text = "Игра начинается ";
        HideMenu();
        //levelImage.SetActive(true);
        StartCoroutine("HideLevelImage", levelStartDelay);
    }


    //Hides black image used between levels
    //void HideLevelImage()
    //{
    //    //Disable the levelImage gameObject.
    //    TransictionUI.gameObject.SetActive(false);
    //    GameUI.gameObject.SetActive(true);
    //}

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

     //GameOver is called when the player reaches 0 food points
    public void GameOver()
    {

    }

    void StartGame()
    {
        InitNewImage();
    }

    public void InitNewImage()
    {
        Instantiate(image, new Vector2(0, 0), Quaternion.identity);
    }
}
