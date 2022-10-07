using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S2ToS1 : MonoBehaviour
{
    GameObject Players;
    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.Find("Players");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DontDestroyOnLoad(Players);
            SceneManager.LoadScene("SampleScene"); 
        }

    }
}
