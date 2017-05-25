using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameInfo
{
    public int idImage;
    public int leftCnt;
    public int rightCnt;

    public GameInfo(int id, int leftCounter, int rightCounter)
    {
        idImage = id;
        leftCnt = leftCounter;
        rightCnt = rightCounter;
    }
}
