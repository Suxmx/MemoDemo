using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 2f);
    }
    
}
