using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryContrller : MonoBehaviour
{
    public GameObject standartCardPrefab;
    public GameObject contentCard;
    public List<ScriptableCards> cardScriptable;

    void Start()
    {
        foreach (ScriptableCards card in cardScriptable) 
        {
            GameObject _objTemp = Instantiate(standartCardPrefab, contentCard.transform);
            _objTemp.GetComponent<CardController>().CardData = card;
            _objTemp.GetComponent<CardController>().LoadCard();
        }
    }
}
