using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jewel : MonoBehaviour
{
    public int Value;
    public GameObject ValueText;
    GameObject ScoreCtrl;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCtrl = GameObject.Find("PlayerScoreCtrl");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreCtrl.GetComponent<ScoreCtrl>().Score += Value;//¼Ó·Ö
            ValueText.gameObject.SetActive(true);
            ValueText.GetComponent<JewelScore>().Score = Value;
            Destroy(this.gameObject, 1f);
        }
    }
}
