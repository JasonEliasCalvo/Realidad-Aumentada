using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Action onMainMenu;
    public Action onInventoryMenu;
    public GameObject mainMenuPanel;
    public GameObject inventoryMenuPanel;

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
