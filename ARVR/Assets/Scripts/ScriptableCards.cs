using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StandartCard", menuName = "ScriptableCard"),]

public class ScriptableCards : ScriptableObject
{
    public int idCard;
    public string cardName;
    [TextArea(3,3)] public string CardDescription;
    public Sprite cardImage;
    public GameObject object3D;  
}
