
using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
    public string nameFile;
    public string initiatePath;
    public string destinationPath;

    public void TakeScreenShot()
    {
        StartCoroutine(IETakeScreenShot());
    }

    public IEnumerator IETakeScreenShot()
    {
        nameFile = "ARVR-"+DateTime.Now.ToString("yyyy-MMM-dd-HH-mm-ss") + ".png";
        initiatePath = Path.Combine(Application.persistentDataPath, nameFile);
        destinationPath = Path.Combine("/storage/emulated/0/DCIM/Camera");

        ScreenCapture.CaptureScreenshot(nameFile);

        yield return new WaitForSeconds(2f);

        MoveFile();
    }

    public void MoveFile()
    {
        string _directoryTemp = Path.GetDirectoryName(destinationPath);
        if (!Directory.Exists(_directoryTemp))
        {
            Directory.CreateDirectory(_directoryTemp);
        }
        
        if (!Directory.Exists(initiatePath))
        {
            File.Move(initiatePath, destinationPath);
        }
    }
}
