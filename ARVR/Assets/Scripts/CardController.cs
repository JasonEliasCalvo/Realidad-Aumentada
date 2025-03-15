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

    public ScriptableCards CardData { get => cardData; set => cardData = value; }

    public void LoadCard()
    {
        nameCard.text = CardData.cardName;
        referentImage.sprite = CardData.cardImage;
        SetButtonAction(() => UIManager.instance.ShowDescriptionPanel(CardData.CardDescription));
    }

    public void CreateObject()
    {
        GameObject gameObjectTemp = Instantiate(CardData.object3D);
        gameObjectTemp.transform.position = gameObjectTemp.transform.right * 2;

        GameManager _gameManager = GameObject.FindObjectOfType<GameManager>();
        _gameManager.DestroyCurrentModel();
        _gameManager.current3DModel = gameObjectTemp;
        _gameManager.CurrentScriptableCard = CardData;
    }

    public void SetButtonAction(UnityEngine.Events.UnityAction action)
    {
        infoButton.onClick.RemoveAllListeners();
        infoButton.onClick.AddListener(action);
    }

}
