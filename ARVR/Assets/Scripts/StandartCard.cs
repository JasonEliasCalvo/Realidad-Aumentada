using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StandartCard : MonoBehaviour
{
    public TextMeshProUGUI nameCard;
    public ScriptableCards formcard;
    public Image icontCard;

    void Start()
    {
        nameCard.text = formcard.cardName;
        icontCard.sprite = formcard.cardImage;
    }
}
