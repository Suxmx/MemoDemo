using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
//#if UNITY_EDITOR //������ڱ༭��������
        //UnityEditor.EditorApplication.isPlaying = false;
//#else//�ڴ�������Ļ�����
    Application.Quit();
//#endif
    }
}
