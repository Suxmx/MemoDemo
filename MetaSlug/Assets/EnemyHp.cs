using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    // Start is called before the first frame update
    public int Hp = 2;
    Animator Ani;
    bool First=true;
    public float DieTime = 0.6f;
    public int Score;
    GameObject ScoreUI;
    void Start()
    {
        ScoreUI = GameObject.Find("PlayerScoreCtrl");
        if(GetComponent<Animator>()!=null)
            Ani = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp -= 1;
        }
        else if (collision.gameObject.tag == "Bullet5")
        {
            Hp -= 5;
        }

        if (Hp <= 0 && First)
        {
            First = false;
            AddScore();
            if (Ani != null)
                Ani.SetTrigger("Die");
            Destroy(this.gameObject, DieTime);
        }

    }
    void AddScore() {
        ScoreUI.GetComponent<ScoreCtrl>().Score += Score;
    }

}
