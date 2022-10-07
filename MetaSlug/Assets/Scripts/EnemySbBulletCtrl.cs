using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySbBulletCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Enemy;
    public int Face = 2;
    public float Speed = 1;
    Vector2 FaceV=Vector2.right;
    void Start()
    {

        Face = 2;
        Destroy(gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Face==2)FaceV=Vector2.right;
        else FaceV=Vector2.left;
        transform.Translate(FaceV * Speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit");
        if(collision.gameObject.tag=="Ground")
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit");
        if (collision.gameObject.tag == "Ground"||collision.gameObject.tag=="DestoryBullet")
            Destroy(this.gameObject);
    }
}
