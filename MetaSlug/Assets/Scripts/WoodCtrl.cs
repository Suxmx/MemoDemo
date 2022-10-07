using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public int Hp=10;
    Animator Ani;
    bool FirstDie = true,FirstTwo=true;
    GameObject Score;
    public int Value = 50;
    void Start()
    {
        Score = GameObject.Find("PlayerScoreCtrl");
        Ani = GetComponent<Animator>();
        Ani.SetInteger("Hp", Hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") Hp--;
        else if (collision.gameObject.tag == "Bullet5") Hp -= 5;
        Ani.SetInteger("Hp", Hp);

        if (Hp<3&&FirstTwo) transform.Translate(Vector2.down * 0.24f);

        if (Hp <= 0 && FirstDie)
        {
            Score.GetComponent<ScoreCtrl>().Score += Value;
            FirstDie = false;
            Destroy(gameObject);
        }

        /*if (collision.gameObject.tag == "Bullet")
        {
            if (Hp > 0) Hp--;
            else
            {
                if (FirstDie)
                {
                    Score.GetComponent<ScoreCtrl>().Score += Value;
                    FirstDie = false;
                    Destroy(gameObject);
                }
            }Ani.SetInteger("Hp", Hp);

            if (Hp == 2) transform.Translate(Vector2.down * 0.24f);
            
        }*/
    }

}
