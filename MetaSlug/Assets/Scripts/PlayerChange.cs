using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public GameObject Player1,Player2,PlayerStand;
    public int PlayerMode = 1;
    bool IfIsFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && PlayerMode == 2)//������̨
        {
            PlayerMode = 1;
            //GetComponent<BatteryMove>().TotalHorizontal = 0;
            //GetComponent<Animator>().SetFloat("Horizontal", 0);
            GetComponent<BatteryMove>().enabled = false;
            Player2.gameObject.SetActive(false);
            Player1.gameObject.SetActive(true);//�л���ɫ
            Player1.transform.position=Player2.transform.position;
            Player1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);//��Ծ����Ծ����
            Player1.GetComponent<Animator>().SetBool("IsJump", true);

            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//����ڿ��д����������������ٶ�������������̨
    {
        if (collision.gameObject.tag == "Player"&&collision.GetComponent<Rigidbody2D>().velocity.y<-0.1f)
        {
            Player2.transform.position = PlayerStand.transform.position;  
            collision.gameObject.SetActive(false);
            Player2.gameObject.SetActive(true);
            PlayerMode = 2;
            GetComponent<BatteryMove>().enabled = true;


        }
    }
}
