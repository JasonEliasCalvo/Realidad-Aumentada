using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public TextMeshProUGUI nameCard;
    public Image referentImage;
    private ScriptableCards cardData;
    public Button infoButton;
    public GameObject ItemModel;
    private ARInterractionManager arInterractionManager;
    public ScriptableCards CardData { get => cardData; set => cardData = value; }


    public void LoadCard()
    {
        nameCard.text = CardData.cardName;
        referentImage.sprite = CardData.cardImage;
        SetButtonAction(() => UIManager.instance.ShowDescriptionPanel(CardData.CardDescription));
        ItemModel = cardData.object3D;
        gameObject.name = CardData.cardName;
    }

    private void Start()
    {
        arInterractionManager = FindObjectOfType<ARInterractionManager>();
        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPointer);
        button.onClick.AddListener(CreateObject);
    }

    public void CreateObject()
    {
        arInterractionManager.Item3DModel = Instantiate(CardData.object3D);
    }

    public void SetButtonAction(UnityEngine.Events.UnityAction action)
    {
        infoButton.onClick.AddListener(action);
    }
}
