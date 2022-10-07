using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForPlayer : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    float offsetx,move;
    void Start()
    {
        Player = GameObject.Find("Player");
        offsetx = transform.position.x-Player.transform.position.x+0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        move = Player.GetComponent<PlayerMove>().CameraMove;
        transform.Translate(new Vector3(move, 0, 0));
        Player.GetComponent<PlayerMove>().CameraMove = 0;

    }
}
