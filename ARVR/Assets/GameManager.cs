using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ScriptableCards CurrentScriptableCard = null;

    public GameObject current3DModel;

    public void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
        else 
            Destroy(gameObject); 
    }

    public void DestroyCurrentModel()
    {
        Destroy(current3DModel);
        current3DModel = null;
        CurrentScriptableCard = null ;
    }

    public void TakeScreenShot()
    {
        ScreenCapture.CaptureScreenshot("capture.png");
    }
}
