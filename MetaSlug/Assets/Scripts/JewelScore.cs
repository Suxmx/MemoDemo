using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelScore : MonoBehaviour
{
    public GameObject[] ScoreUI;
    public int Score;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    private void Update()
    {
        int tempScore=Score;
        for(int i = 1; i <= 3; i++)
        {
            ScoreUI[i].GetComponent<Animator>().SetFloat("Score", (float)(tempScore % 10));
            tempScore /= 10;
        }
    }
    // Update is called once per frame

}
