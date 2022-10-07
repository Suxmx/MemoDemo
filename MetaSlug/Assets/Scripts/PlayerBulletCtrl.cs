using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    public float BulletSpeed=1;
    public int Face = 1;
    public float DestroyTime = 0.6f;
    void Start()
    {
        Player = GameObject.Find("Player");
        Destroy(this.gameObject, DestroyTime);
        if (Face == 1)
        {
            transform.localScale = new Vector3(-0.75f, -0.75f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Face==1)transform.Translate(Vector2.left * Time.deltaTime * BulletSpeed);
        else transform.Translate(Vector2.right * Time.deltaTime * BulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "OldMan" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
