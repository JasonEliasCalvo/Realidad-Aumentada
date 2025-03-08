using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Action onMainMenu;
    public Action onInventoryMenu;
    public GameObject mainMenuPanel;
    public GameObject inventoryMenuPanel;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        onMainMenu += OnMainMenu;
        onInventoryMenu += OnInventoryMenu;
    }

    public void OnMainMenu()
    {
        mainMenuPanel.SetActive(true);
        inventoryMenuPanel.SetActive(false);
    }

    public void OnInventoryMenu()
    {
        mainMenuPanel.SetActive(false);
        inventoryMenuPanel.SetActive(true);
    }
}
