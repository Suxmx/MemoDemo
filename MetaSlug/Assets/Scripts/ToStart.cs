using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;
    public bool ifstart = false;
    public GameObject TextM1;
    public TextMeshProUGUI Text1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Start")
        {
            camera.transform.Translate(Vector2.right * 8.3f);
            ifstart = true;
            transform.position = new Vector3(5.5f, -2.7f, 0);
            TextM1 = GameObject.FindGameObjectWithTag("Text");
            
            Invoke("TextChange", 1f);
        }
    }
    void TextChange()
    {
        
        
        Destroy(TextM1);
        Invoke("DestoryText", 1);
    }
    void DestoryText()
    {
        Destroy(TextM1);
    }
}
