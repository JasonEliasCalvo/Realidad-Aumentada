using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI descriptionCard;
    public GameObject descriptionCardPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject inventoryMenuPanel;
    [SerializeField] private GameObject PointerMenuPanel;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        GameManager.instance.onMainMenu += OnMainMenu;
        GameManager.instance.onInventoryMenu += OnInventoryMenu;
        GameManager.instance.onPointerMenu += OnPointerMenu;

        OnMainMenu();
    }

    public void OnMainMenu()
    {
        mainMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);

        inventoryMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        inventoryMenuPanel.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        inventoryMenuPanel.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        PointerMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        PointerMenuPanel.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        //mainMenuPanel.SetActive(true);
        //inventoryMenuPanel.SetActive(false);
    }

    public void OnInventoryMenu()
    {
        mainMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        inventoryMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        inventoryMenuPanel.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        inventoryMenuPanel.transform.GetChild(1).transform.DOMoveY(300, 0.3f);

        //mainMenuPanel.SetActive(false);
        //inventoryMenuPanel.SetActive(true);
    }

    public void OnPointerMenu()
    {
        mainMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        inventoryMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        inventoryMenuPanel.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        inventoryMenuPanel.transform.GetChild(1).transform.DOMoveY(10, 0.3f);

        PointerMenuPanel.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        PointerMenuPanel.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);

        //mainMenuPanel.SetActive(false);
        //inventoryMenuPanel.SetActive(true);
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
