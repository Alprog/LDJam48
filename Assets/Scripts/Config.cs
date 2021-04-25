
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance;

    public float HeroSpeed = 5;

    public float SeekForce = 300;
    public float SeparateDistance = 100;
    public float AvoidForce = 1000;

    public float VerticalScale = 1;

    public Sprite CircleSprite;
    public Sprite ShadowSprite;

    public List<Sprite> WhiteIdleSheet;
    public List<Sprite> GnomeIdleSheet;
    public List<Sprite> EnemyRunSheet;

    public ShadowMode ShadowMode;

    public void Start()
    {
        Instance = this;
    }
}
