using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] SpawnPoint;
    public GameObject[] Enemy;
    public float[] EnemyTime;
    public float EndTime;
    GameObject FindEnemy;
    bool PreToEnd=false;
    public GameObject EndAndTrans;
    public GameObject MissionAccomplished;
    void Start()
    {
        //SpawnPoint = new Transform[SpawnPoint.Length];
        //0~2Ϊpoint1
        //3~5Ϊpoint2
        //6~11Ϊpoint3
        //E1 右3
        //E2 左3
        //E3 jet
        //E4 一大波
        //E5 左右各二
        Invoke("E1", EnemyTime[0]);//第一批敌人在二秒后生成
        Invoke("E1", EnemyTime[1]);
        Invoke("E1", EnemyTime[2]);
        Invoke("E3", EnemyTime[3]);
        Invoke("E2", EnemyTime[4]);
        Invoke("E5", EnemyTime[5]);
        Invoke("E4", EnemyTime[6]);
        Invoke("E5", EnemyTime[7]);
        Invoke("E3", EnemyTime[8]);
        Invoke("E4", EnemyTime[9]);
        Invoke("E4", EnemyTime[10]);
        Invoke("E3", EnemyTime[11]);
        Invoke("ToEnd",EndTime);//激活准备结束程序，把PreEnd设为true，使得探测程序在update里面运行
    }

    // Update is called once per frame
    void Update()
    {
        if (PreToEnd)
        {
            IfEnd();
        }
    }
    void E1()//右边生成三只空降兵
    {
        Instantiate(Enemy[0], SpawnPoint[0].position, SpawnPoint[3].rotation);
        Instantiate(Enemy[0], SpawnPoint[1].position, SpawnPoint[4].rotation);
        Instantiate(Enemy[0], SpawnPoint[2].position, SpawnPoint[5].rotation);
    }
    void E2()//左边生成三只空降兵
    {
        Instantiate(Enemy[0], SpawnPoint[3].position, SpawnPoint[3].rotation);
        Instantiate(Enemy[0], SpawnPoint[4].position, SpawnPoint[4].rotation);
        Instantiate(Enemy[0], SpawnPoint[5].position, SpawnPoint[5].rotation);
    }
    void E3()//生成一只飞机在正中间
    {
        Instantiate(Enemy[1], SpawnPoint[11].position, SpawnPoint[11].rotation);
    }
    void E4()//生成一大波空降兵
    {
        Instantiate(Enemy[0], SpawnPoint[6].position, SpawnPoint[6].rotation);
        Instantiate(Enemy[0], SpawnPoint[7].position, SpawnPoint[7].rotation);
        Instantiate(Enemy[0], SpawnPoint[8].position, SpawnPoint[8].rotation);
        Instantiate(Enemy[0], SpawnPoint[9].position, SpawnPoint[9].rotation);
        Instantiate(Enemy[0], SpawnPoint[10].position, SpawnPoint[10].rotation);
        Instantiate(Enemy[0], SpawnPoint[11].position, SpawnPoint[11].rotation);
    }
    void E5()//左右各二
    {
        Instantiate(Enemy[0], SpawnPoint[0].position, SpawnPoint[3].rotation);
        Instantiate(Enemy[0], SpawnPoint[1].position, SpawnPoint[4].rotation);
        Instantiate(Enemy[0], SpawnPoint[6].position, SpawnPoint[6].rotation);
        Instantiate(Enemy[0], SpawnPoint[7].position, SpawnPoint[7].rotation);
    }
    void ToEnd()
    {
        PreToEnd = true;
    }
    void IfEnd()
    {
        FindEnemy = GameObject.FindGameObjectWithTag("Enemy");
        if (FindEnemy != null) Debug.Log("Still Have Enemy");
        else
        {
            MissionAccomplished.SetActive(true);
            Invoke("End",1f);
        }
    }
    void End()
    {   
        MissionAccomplished.SetActive(false);
        EndAndTrans.gameObject.SetActive(true);
        
    }
}
