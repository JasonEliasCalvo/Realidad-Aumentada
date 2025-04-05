using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StandartCardController : MonoBehaviour
{
    public TextMeshProUGUI nameCard;
    public Image referentImage;
    private ScriptableCards cardData;
    public Button infoButton;
    private ARInterractionManager arInterractionManager;
    public ScriptableCards CardData { get => cardData; set => cardData = value; }


    public void LoadCard()
    {
        nameCard.text = CardData.cardName;
        referentImage.sprite = CardData.cardImage;
        SetButtonAction(() => UIManager.instance.ShowDescriptionPanel(CardData.CardDescription));
    }

    private void Start()
    {
        arInterractionManager = FindObjectOfType<ARInterractionManager>();
    }

    public void CreateObject()
    {
        foreach (Transform child in GameManager.instance.containerModels)
        {
            Destroy(child.gameObject);
        }

        GameObject gameObjectTemp = Instantiate(CardData.object3D, GameManager.instance.containerModels);
        arInterractionManager.Item3DModel = gameObjectTemp;
    }

    public void SetButtonAction(UnityEngine.Events.UnityAction action)
    {
        infoButton.onClick.RemoveAllListeners();
        infoButton.onClick.AddListener(action);
    }
}
