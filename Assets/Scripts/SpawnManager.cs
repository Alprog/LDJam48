
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static int SpawnAttempts = 200;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnEnemy(Config.Instance.WhiteEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SpawnEnemy(Config.Instance.YellowEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SpawnEnemy(Config.Instance.RedEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SpawnEnemy(Config.Instance.GreenEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SpawnAtRandomFreePlace(Config.Instance.ObstaclePrefab);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SpawnAtRandomFreePlace(Config.Instance.GnomePrefab);
    }

    public void Start()
    {
        Spawn(Config.Instance.DrillCarPrefab, WalkZone.Instance.GetDrillPoint());

        SpawnAtRandomFreePlace(Config.Instance.HeroPrefab);
    }

    public void SpawnAtRandomFreePlace(CircleObject prefab)
    {
        for (int i = 0; i < SpawnAttempts; i++)
        {
            var point = WalkZone.Instance.GetRandomPoint(prefab.Radius);
            if (!WalkZone.Instance.CollideAny(point, prefab.Radius, null, true))
            {
                Spawn(prefab, point);
                return;
            }
        }

        Debug.LogError("Can't spawn " + prefab.name);
    }

    public void SpawnEnemy(CircleObject prefab)
    {
        var point = WalkZone.Instance.GetRandomEnemyPoint(prefab.Radius);
        Spawn(prefab, point);
    }

    public void Spawn(CircleObject prefab, Vector2 point)
    {
        var instance = GameObject.Instantiate(prefab);
        instance.name = prefab.name;
        instance.transform.SetParent(GameObject.Find("SortObjects").transform);
        instance.gameObject.SetActive(true);
        instance.Position = point;
        instance.transform.position = new Vector2(point.x, point.y * Config.Instance.VerticalScale);
        instance.Init();
    }
}
