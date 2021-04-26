
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance;

    public float HeroSpeed = 5;
    public float HeroPriorityK = 2;
    public float VerticalScale = 1;

    public Sprite CircleSprite;
    public Sprite ShadowSprite;
    public Sprite BloodSprite;
    public Sprite SlimeSprite;

    public List<Sprite> WhiteIdleSheet;
    public List<Sprite> GnomeIdleSheet;
    public List<Sprite> EnemyRunSheet;

    public ShadowMode ShadowMode;


    public CircleObject HeroPrefab;
    public CircleObject GnomePrefab;
    public CircleObject ObstaclePrefab;
    public CircleObject WhiteEnemyPrefab;
    public CircleObject YellowEnemyPrefab;
    public CircleObject RedEnemyPrefab;
    public CircleObject GreenEnemyPrefab;
    public CircleObject DrillCarPrefab;

    public void Start()
    {
        Instance = this;
    }
}
