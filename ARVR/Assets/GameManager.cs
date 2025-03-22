using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action onMainMenu;
    public event Action onInventoryMenu;

    public ScriptableCards CurrentScriptableCard = null;

    public GameObject current3DModel;

    public void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else 
            instance = this;
    }

    public void DestroyCurrentModel()
    {
        Destroy(current3DModel);
        current3DModel = null;
        CurrentScriptableCard = null ;
    }

    private void Start()
    {
        MainMenu();
    }

    private void MainMenu()
    {
        onMainMenu?.Invoke();
    }

    private void InventoryMenu()
    {
        onInventoryMenu?.Invoke();
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
