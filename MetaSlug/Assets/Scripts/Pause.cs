using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    bool IfPause = false;
    public GameObject PauseImage;
    public void ClickPause()
    {
        if (IfPause)
        {
            Time.timeScale = 1;
            IfPause = false;
            PauseImage.gameObject.SetActive(false); 
        }
        else
        {
            Time.timeScale = 0;
            IfPause = true;
            PauseImage.gameObject.SetActive(true);
        }
    }

}
