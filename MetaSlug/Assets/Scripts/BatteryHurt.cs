using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHurt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player1,Player2,Health,Battery;
    void Start()
    {
        Battery = GameObject.Find("Battery");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Battery.GetComponent<PlayerChange>().PlayerMode = 1;//切换玩家模式防止出现跳跃bug
            //Battery.GetComponent<BatteryMove>().TotalHorizontal = 0;
            //Battery.GetComponent<Animator>().SetFloat("Horizontal", 0);

            Player2.transform.position = Battery.transform.position+ Vector3.up*10+Vector3.right*1.5f;//往右上重生
            Player1.gameObject.SetActive(true);//切换为角色1
            Player1.transform.position=Player2.transform.position;//给角色1位置
            Health.GetComponent<PlayerHealth>().NowLives--;//受伤系统
            //Invoke("ReBurn", 0.5f);
            Player2.gameObject.SetActive(false);//完成转换，关闭角色2
            
            
        }
    }
    void ReBurn()
    {
        
        
    }
}
