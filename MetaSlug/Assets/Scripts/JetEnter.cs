using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetEnter : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject EnterPoint;
    void Start()
    {
        EnterPoint = GameObject.Find("JetEnterPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(EnterPoint.transform.position, transform.position) > 0.15f)
            transform.Translate((EnterPoint.transform.position - transform.position) * Time.deltaTime * 5f);
        else
        {
            GetComponent<JetMove>().enabled = true;
        }     
    }
}
