using UnityEngine;

[CreateAssetMenu(fileName ="New PlayerInfo", menuName ="PlayerInfo")]
public class PlayerColorInformation : ScriptableObject {

    public Sprite BallInactive;
    public Sprite BallActive;
    public Color PlayerHudColor;
    public Color RespawnCounterColor;
    public Material ColorMaterial;
    public Material HitEfectMaterial;
}
