using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ScoreInUI;
    public int Score;
    int[] Scores;

    void Start()
    {
        Scores = new int[ScoreInUI.Length];
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        int TempScore = Score;
        for (int i = 1; i <= 6; i++)
        {
            Scores[i] = TempScore % 10;
            TempScore /= 10;
            ScoreInUI[i].GetComponent<Animator>().SetFloat("Score", (float)Scores[i]);
        }
        

    }
}
