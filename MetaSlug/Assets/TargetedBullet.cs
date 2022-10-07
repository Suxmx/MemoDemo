using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class TargetedBullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Target;
    public float PreTime = 0.15f;
    public int Speed,Force=40;
    public GameObject Center;
    Vector2 FaceV = Vector2.right;
    bool Enter=true;
    Vector3 R;
    Animator Ani;

    void Start()
    {
        Ani= GetComponent<Animator>();
        Destroy(gameObject,3f);
        Target = GameObject.FindWithTag("Enemy");
        if(Target==null) Target = GameObject.FindWithTag("OldMan");
        
        if (Target != null)
        {
            if (transform.position.y < Target.transform.position.y)
            {
                transform.Rotate(new Vector3(0, 0, 90));
                R = new Vector3(0, 0, -90);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -90));
                R = new Vector3(0, 0, 90);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Target!=null){
            if (Mathf.Abs(transform.position.y - Target.transform.position.y) < 0.2f && Enter)
            {
                Enter = false;
                transform.Rotate(R);
            } 
        }
        
            transform.Translate(Vector2.right*Time.deltaTime*Speed);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "OldMan")
        {
            Ani.SetTrigger("Boom");
            //gameObject.tag = "Player";
            Speed = 0;
            Destroy(this.gameObject, 0.25f);
        }
    }

}
