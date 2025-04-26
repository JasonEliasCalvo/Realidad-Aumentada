using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI debugText;
    internal Transform containerModels;

    public event Action onMainMenu;
    public event Action onInventoryMenu;
    public event Action onPointerMenu;

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

    public void MainMenu()
    {
        onMainMenu?.Invoke();
    }

    public void InventoryMenu()
    {
        onInventoryMenu?.Invoke();
    }

    public void ARPointer()
    {
        onPointerMenu?.Invoke();
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
