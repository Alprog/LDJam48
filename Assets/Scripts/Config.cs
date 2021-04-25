
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance;

    public float HeroSpeed = 5;

    public float SeekForce = 300;
    public float SeparateDistance = 100;
    public float AvoidForce = 1000;
    public float Mass = 3;

    public float VerticalScale = 1;

    public Sprite CircleSprite;
    public Sprite ShadowSprite;

    public ShadowMode ShadowMode;

    public void Start()
    {
        Instance = this;
    }
}
