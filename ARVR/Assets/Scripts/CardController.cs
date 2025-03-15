using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public TextMeshProUGUI nameCard;
    public Image referentImage;
    public ScriptableCards cardData;
    public Button infoButton;

    public void LoadCard()
    {
        nameCard.text = cardData.cardName;
        referentImage.sprite = cardData.cardImage;
        SetButtonAction(() => UIManager.instance.ShowDescriptionPanel(cardData.CardDescription));
    }

    public void CreateObject()
    {
        GameObject gameObjectTemp = Instantiate(cardData.object3D);
        gameObjectTemp.transform.position = gameObjectTemp.transform.right * 2;

        GameManager _gameManager = GameObject.FindObjectOfType<GameManager>();
        _gameManager.DestroyCurrentModel();
        _gameManager.current3DModel = gameObjectTemp;
        _gameManager.CurrentScriptableCard = cardData;
    }

    public void SetButtonAction(UnityEngine.Events.UnityAction action)
    {
        infoButton.onClick.RemoveAllListeners();
        infoButton.onClick.AddListener(action);
    }

}
