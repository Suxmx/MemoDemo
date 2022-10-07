using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSceen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Health;
    Animator Ani;
    float NowLives;
    void Start()
    {
        Ani=GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        NowLives = Health.GetComponent<PlayerHealth>().NowLives;
        Ani.SetFloat("Lives", NowLives);
    }
}
