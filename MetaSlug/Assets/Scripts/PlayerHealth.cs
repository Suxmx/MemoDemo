using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int Lives=10,NowLives=10;
    public GameObject Player,PlayerBody,End;
    public float LastDeath = 3;
    public float UnHurt=2.5f;//总分数
    
    

    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {

        Camera = GameObject.Find("Main Camera");
        //Player = GameObject.Find("Player");
        //PlayerBody = GameObject.Find("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
        LastDeath += Time.deltaTime;
        if (Lives > NowLives&&LastDeath>=UnHurt)//若检测到生命变化就进入Die程序
        {
            LastDeath = 0;
            Die();
        }
        else if(Lives>NowLives)
        {
            NowLives++;
        }
        
    }
    void Die()
    {
        PlayerBody.SetActive(false);//隐藏身体以便播放动画
        Player.GetComponent<PlayerMove>().enabled = false;
        Player.GetComponent<Animator>().SetTrigger("Die");//控制脚的动画机来控制动画
        if (NowLives > 0)//如果还有生命就减一并重生
        {
            Lives = NowLives;
            Invoke("ReBurn", 0.6f);
        }
        else
        {
            End.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void ReBurn()
    {
        
        PlayerBody.SetActive(true);//恢复身体
        Player.transform.position = Camera.transform.position + Vector3.up * 5+new Vector3(-3,0,10);//从上方坠落
        Invoke("AwakeMove",1);
    }
    void AwakeMove()
    {
        Player.GetComponent<PlayerMove>().enabled = true;
    }
    
}
