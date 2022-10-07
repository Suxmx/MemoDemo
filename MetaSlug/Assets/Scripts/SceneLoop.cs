using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoop : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 StartPoint, EndPoint;
    public float SceneSpeed=1;
    void Start()
    {
        StartPoint = new Vector3(16f,-0.68f,0);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left *SceneSpeed*Time.deltaTime );
        //Debug.Log(transform.position);
        if ( transform.position.x<-5.6f)
        {
            transform.position=StartPoint;
            //Debug.Log("test");
        }
    }
}
