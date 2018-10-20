using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New PlayerInfo", menuName ="PalyerInfo")]
public class PlayerHudInformation : ScriptableObject {

    public int PlayerNumber;
    public Sprite BallInactive;
    public Sprite BallActive;
    public Color PlayerColor;
    public Color LifeCellColor;

}
