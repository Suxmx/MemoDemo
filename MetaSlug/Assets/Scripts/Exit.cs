using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
//#if UNITY_EDITOR //如果是在编辑器环境下
        //UnityEditor.EditorApplication.isPlaying = false;
//#else//在打包出来的环境下
    Application.Quit();
//#endif
    }
}
