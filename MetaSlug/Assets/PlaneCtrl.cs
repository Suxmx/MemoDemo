using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneCtrl : MonoBehaviour
{       
    public GameObject PlaneBattery;
    public float Speed = 1;
    public GameObject Camera;
    Animator Ani;
    Rigidbody2D rd;

    Vector3 UpOffset = new Vector3(0, 0.0417f, 0);
    Vector3 DownOffset = new Vector3(0, -0.0693f, 0);
    Vector3 Offset;
    Vector3 CameraOffset;

    

    
    float Vertical=0, Rotation=0;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        CameraOffset= Camera.transform.position-transform.position;
        rd = GetComponent<Rigidbody2D>();
        Offset=PlaneBattery.transform.position-transform.position;
        DownOffset += Offset;
        UpOffset += Offset;//初始化炮台动画偏移值

        Ani=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraFollow();
    }
    void Move()
    {
        rd = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.W))
        {
            Vertical = 1;
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
            PlaneBattery.transform.position = UpOffset + transform.position;//处理炮台动画偏移值


        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vertical = -1;
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
            PlaneBattery.transform.position = DownOffset + transform.position;
        }
        else 
        {
            Vertical = 0;
            PlaneBattery.transform.position = Offset + transform.position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rd.AddForce(new Vector2(1.5f,0) * Time.deltaTime * Speed*50);
        }
        Ani.SetFloat("Vertical", Vertical);
    }
    void CameraFollow()
    {
        Camera.transform.position = CameraOffset + transform.position;
    }
}
