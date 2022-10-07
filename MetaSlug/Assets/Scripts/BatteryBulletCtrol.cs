using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BatteryBulletCtrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 4;
    GameObject Battery;
    int Face;
    void Start()
    {
        Battery = GameObject.Find("PlayerBattery");
        Destroy(gameObject,3f);
        Face = Battery.GetComponent<SpriteRenderer>().flipX==true?1:-1;//���ݽ�ɫ�ĳ�������ӵ��ķ��䷽��
  
    }

    // Update is called once per frame
    void Update()
    {
        if(Face==1)transform.Translate(Vector2.right * 4 * Time.deltaTime);//ʵ���ӵ����䷽��Ľ���
        else transform.Translate(Vector2.left * 4 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
