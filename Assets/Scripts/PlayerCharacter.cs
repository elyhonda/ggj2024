using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public enum personagem {char1, char2, char3, char4};
public class PlayerCharacter : MonoBehaviour
{
    public personagem character;
    public Image characterImage;
}