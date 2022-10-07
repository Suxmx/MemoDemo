using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBatteryCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public float Rotation = 0,PerFire=0.2f;
    public int Speed = 50;
    public GameObject FirePoint,Bullet;

    float NowTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Shoot();
    }
    void Rotate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Rotation+=Time.deltaTime*Speed;
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * Speed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Rotation-=Time.deltaTime*Speed;
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * Speed));
        }

        
    }
    void Shoot()
    {
        NowTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.J)&&NowTime>=PerFire)
        {
            NowTime = 0;
            Instantiate(Bullet, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }


}
