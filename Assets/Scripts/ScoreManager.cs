using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CounterSide
{
    Right = 0,
    Left
}

public class ScoreManager : MonoBehaviour
{
    public Text rightCounter;
    public Text leftCounter;

    private int leftC;
    private int rightC;

    public int LeftCnt { get { return leftC; } set { leftC = value;
            UpdateLabels();
        } }
    public int RightCnt
    {
        get { return rightC; }
        set
        {
            rightC = value;
            UpdateLabels();
        }
    }
    public static ScoreManager instance = null;


    void Start ()
    {
        rightCounter.text = "0";
        leftCounter.text = "0";
	}

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public void AddScore(CounterSide side)
    {
        switch ((int)side)
        {
            case 0:
                RightCnt++;
                break;
            case 1:
                LeftCnt++;
                break;
            default:
                break;
        }
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        rightCounter.text = RightCnt.ToString();
        leftCounter.text = LeftCnt.ToString();
    }

}
