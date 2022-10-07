using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MottoCtrl : MonoBehaviour
{
    // Start is called before the first frame update\
    GameObject Player;
    Vector2 FaceV = Vector2.left;
    public int Speed = 5;
    void Start()
    {
        Player = GameObject.Find("Player");
        Destroy(this.gameObject, 6f);
        if (transform.position.x > Player.transform.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            FaceV = Vector2.left;
        }
        else
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            FaceV = Vector2.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(FaceV * Time.deltaTime * Speed);
    }
    
}
