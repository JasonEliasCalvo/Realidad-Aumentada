using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Action onMainMenu;
    public Action onInventoryMenu;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject inventoryMenuPanel;
    public TextMeshProUGUI descriptionCard;
    public GameObject descriptionCardPanel;

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

    public void ShowDescriptionPanel(string currentDescription)
    {
        descriptionCardPanel.SetActive(true);
        descriptionCard.text = string.Empty;
        descriptionCard.text = currentDescription;
    }

    public void HideDescriptionPanel()
    {
        descriptionCardPanel.SetActive(false);
    }
}
