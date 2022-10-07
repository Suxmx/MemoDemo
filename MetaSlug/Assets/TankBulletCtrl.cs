using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
}
