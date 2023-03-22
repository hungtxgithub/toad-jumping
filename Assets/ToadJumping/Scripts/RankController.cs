using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankController : MonoBehaviour
{
    private static RankController instance;
    public static RankController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<RankController>();
            }
            return instance;
        }
    }


    public Text bestScore;
    public Text totalScore;

    private int intBestScore;

    //private SaveFile saveFile = new SaveFile();



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //intBestScore = SaveFile.Instance.getBestScore();
        intBestScore = SaveFile.Instance.getBestScore();
        getBestScore();
        getTotalScore(SaveFile.Instance.getlastScore());
    }

    public void getBestScore()
    {
        bestScore.text = intBestScore.ToString();
    }

    public void getTotalScore(int score)
    {
        if (score > intBestScore)
        {
            intBestScore = score;
            getBestScore();
            SaveFile.Instance.setBestScore(score);
        }

        totalScore.text = score.ToString();
        SaveFile.Instance.setLastScore(score);
    }



}
