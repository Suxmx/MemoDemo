using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1ToS2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player1, Player2,Loading,CameraTrans;
    GameObject Players,UI,Camera;
    void Start()
    {
        Players = GameObject.Find("Players");
        UI = GameObject.Find("UI");
        Camera = GameObject.Find("Main Camera");
        Destroy(Player2);//�ݻ���̨��ɫ�Է���

        Player1.GetComponent<PlayerMove>().PlayerBig *= 1.5f;
        Player1.GetComponent<PlayerMove>().OriginSpeed *= 2;
        Player1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Camera.transform.position = new Vector3(1f, 1, -10);//���ƶ�����������
        Player1.SetActive(true);
        Player1.transform.position = new Vector3(0.5f, 1, 1);//���ƶ���ɫ�����
        CameraTrans.SetActive(true);

        //����Loading����
        Loading.gameObject.SetActive(true);
        Invoke("EndLoading", 1.5f);

        DontDestroyOnLoad(Players);//������ɫ
        DontDestroyOnLoad(UI);//����UI
        DontDestroyOnLoad(Camera);//���������
        SceneManager.LoadScene("Level2");//���س���2��
        Destroy(Loading, 0.8f);

        




    }

    // Update is called once per frame
    void Update()
    {
        
            
        
    }
    void EndLoading()
    {
        
    }
}
