using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI debugText;

    public event Action onMainMenu;
    public event Action onInventoryMenu;
    public Transform containerModels;

    public void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else 
            instance = this;
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

    public void DebugConsoleMessage(string message)
    {
        debugText.text = message;
    }
}
