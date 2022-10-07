using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score;
    GameObject ScoreUI;
    bool Trigger=false;
    void Start()
    {
        ScoreUI = GameObject.Find("Scores");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
