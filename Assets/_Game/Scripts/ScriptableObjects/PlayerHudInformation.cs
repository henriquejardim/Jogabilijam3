using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New PlayerInfo", menuName ="PalyerInfo")]
public class PlayerHudInformation : ScriptableObject {

    public Sprite BallInactive;
    public Sprite BallActive;
    public Color PlayerHudColor;
    public Color RespawnCounterColor;
    public Material ColorMaterial;
    public Material HitEfectMaterial;
}
