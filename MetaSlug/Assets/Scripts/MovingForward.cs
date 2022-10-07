using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    Transform StartPoint;
    GameObject Battery,PlayerStand,Camera,Player,Scene;
    public GameObject Enemy;
    public GameObject PlayerHealth;
    public Transform EndPoint;
    
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Scene = GameObject.Find("WhileScene");
        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        Battery = GameObject.Find("Battery");
        PlayerStand = GameObject.Find("PlayerStandPoint");
        
        
        offset = Camera.transform.position-transform.position+Vector3.up*0.75f;//获取初始摄像机偏移值

        
        
        Player.gameObject.GetComponent<PlayerMove>().enabled=false;//先暂时关闭对玩家的控制以防bug
        Battery.gameObject.GetComponent<BoxCollider2D>().enabled = false;//炮塔同理
        StartPoint= transform;
        Invoke("AwakePlayer", 2.2f);//三秒后唤醒控制以及炮台的使用
        Invoke("AwakeSceneLoop", 2.2f);//开始场景的循环
        Invoke("AwakeHealth", 3.5f);//给予一定时间的无敌
        Invoke("AwakeEnemySpawn", 2.3f);//开始敌人生成
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position,Time.deltaTime*0.6f);//插值实现移动
        Player.transform.position = PlayerStand.transform.position;//使角色实时跟随车
        Player.GetComponent<Animator>().SetBool("IsJump", false);
        Camera.transform.position = offset + transform.position;//摄像头跟随
    }
    void AwakePlayer()//解锁角色与炮台使用
    {
        Player.gameObject.GetComponent<PlayerMove>().enabled = true;
        
        Battery.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    void AwakeSceneLoop()
    {
        Scene.GetComponent<SceneLoop>().enabled = true;
    }
    
    void AwakeEnemySpawn()
    {
        Enemy.gameObject.SetActive(true);
    }
    void AwakeHealth()
    {
        PlayerHealth.gameObject.SetActive(true);    
    }
}
