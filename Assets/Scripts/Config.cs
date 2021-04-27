
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance;

    public float HeroSpeed = 5;
    public float HeroPriorityK = 2;
    public float VerticalScale = 1;
    public float NeedCoal = -100;

    public float InteractiveDistance = 15;

    public Sprite CircleSprite;
    public Sprite ShadowSprite;
    public Sprite BloodSprite;
    public Sprite SlimeSprite;
    
    public List<Sprite> WhiteIdleSheet;
    public List<Sprite> WhiteRunSheet;
    public List<Sprite> WhiteGrabGnomeSheet;
    public List<Sprite> WhiteGrabGnomeRunSheet;
    public List<Sprite> GnomeIdleSheet;
    public List<Sprite> EnemyRunSheet;
    public List<Sprite> GnomeMiningSheet;

    public ShadowMode ShadowMode;
    
    public CircleObject HeroPrefab;
    public CircleObject GnomePrefab;
    public CircleObject ObstaclePrefab;
    public CircleObject WhiteEnemyPrefab;
    public CircleObject YellowEnemyPrefab;
    public CircleObject RedEnemyPrefab;
    public CircleObject GreenEnemyPrefab;
    public CircleObject DrillCarPrefab;
    public CircleObject BlueBulletPrefab;
    public CircleObject RedBulletPrefab;
    public CircleObject GoldPrefab;
    public CircleObject CoalPrefab;

    public void Start()
    {
        Instance = this;
    }
}
