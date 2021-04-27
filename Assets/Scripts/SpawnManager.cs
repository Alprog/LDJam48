
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private const int SpawnAttempts = 200;
    private const float SafeOffset = 50;
    private Stage Stage;
    private Wave Wave;
    public float DangerLevel { get; private set; }
    public float DangerPoints { get; private set; }

    public void Start()
    {
        Instance = this;

        Stage = Stages.Levels[Stages.Index];
        Wave = Stage.SelectWave();
        DangerLevel = Stage.DangerStartLevel;

        Spawn(Config.Instance.DrillCarPrefab, WalkZone.Instance.GetDrillPoint());
        Spawn(Config.Instance.HeroPrefab, new Vector2(0, -150));

        for (int i = 0; i < Stage.ObstacleCount; i++) SpawnAtRandomFreePlace(Config.Instance.ObstaclePrefab);
        for (int i = 0; i < Stage.GoldCount; i++) SpawnAtRandomFreePlace(Config.Instance.GoldPrefab, SafeOffset);
        for (int i = 0; i < Stage.CoalCount; i++) SpawnAtRandomFreePlace(Config.Instance.CoalPrefab, SafeOffset);
        for (int i = 0; i < Stage.GnomeCount; i++) SpawnAtRandomFreePlace(Config.Instance.GnomePrefab, SafeOffset);
    }

    public void Update()
    {
        // cheats
        // if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnEnemy(Config.Instance.WhiteEnemyPrefab);
        // if (Input.GetKeyDown(KeyCode.Alpha2)) SpawnEnemy(Config.Instance.YellowEnemyPrefab);
        // if (Input.GetKeyDown(KeyCode.Alpha3)) SpawnEnemy(Config.Instance.RedEnemyPrefab);
        // if (Input.GetKeyDown(KeyCode.Alpha4)) SpawnEnemy(Config.Instance.GreenEnemyPrefab);
        // if (Input.GetKeyDown(KeyCode.Alpha5)) SpawnAtRandomFreePlace(Config.Instance.ObstaclePrefab);
        // if (Input.GetKeyDown(KeyCode.Alpha6)) SpawnAtRandomFreePlace(Config.Instance.GnomePrefab);

        DangerLevel += Stage.DangerGrowSpeed * Time.deltaTime;
        DangerPoints += DangerLevel * Time.deltaTime;

        var wavePrice = Wave.GetPrice();
        if (DangerPoints >= wavePrice)
        {
            DangerPoints -= wavePrice;
            Wave = Stage.SelectWave();
            for (int i = 0; i < Wave.White; i++) SpawnEnemy(Config.Instance.WhiteEnemyPrefab);
            for (int i = 0; i < Wave.Yellow; i++) SpawnEnemy(Config.Instance.YellowEnemyPrefab);
            for (int i = 0; i < Wave.Red; i++) SpawnEnemy(Config.Instance.RedEnemyPrefab);
            for (int i = 0; i < Wave.Green; i++) SpawnEnemy(Config.Instance.GreenEnemyPrefab);
        }
    }

    public CircleObject SpawnAtRandomFreePlace(CircleObject prefab, float safeOffset = 0)
    {
        for (int i = 0; i < SpawnAttempts; i++)
        {
            var point = WalkZone.Instance.GetRandomPoint(prefab.Radius + safeOffset);
            if (!WalkZone.Instance.CollideAny(point, prefab.Radius, null))
            {
                return Spawn(prefab, point);
            }
        }

        Debug.LogError("Can't spawn " + prefab.name);
        return null;
    }

    public CircleObject SpawnEnemy(CircleObject prefab)
    {
        var point = WalkZone.Instance.GetRandomEnemyPoint(prefab.Radius);
        return Spawn(prefab, point);
    }

    public CircleObject Spawn(CircleObject prefab, Vector2 point)
    {
        var instance = GameObject.Instantiate(prefab);
        instance.name = prefab.name;
        instance.transform.SetParent(GameObject.Find("SortObjects").transform);
        instance.gameObject.SetActive(true);
        instance.Position = point;
        instance.transform.position = new Vector2(point.x, point.y * Config.Instance.VerticalScale);
        instance.Init();
        return instance;
    }
}
