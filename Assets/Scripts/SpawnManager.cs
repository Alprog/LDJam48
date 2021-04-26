
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnAtRandomPoint(Config.Instance.WhiteEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SpawnAtRandomPoint(Config.Instance.YellowEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SpawnAtRandomPoint(Config.Instance.RedEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SpawnAtRandomPoint(Config.Instance.GreenEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SpawnAtRandomPoint(Config.Instance.ObstaclePrefab);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SpawnAtRandomPoint(Config.Instance.GnomePrefab);
    }

    public void Start()
    {
        Spawn(Config.Instance.DrillCarPrefab, WalkZone.Instance.GetDrillPoint());

        SpawnAtRandomPoint(Config.Instance.HeroPrefab);
    }

    public void SpawnAtRandomPoint(CircleObject prefab)
    {
        Spawn(prefab, WalkZone.Instance.GetRandomPoint(prefab.Radius));
    }

    public void Spawn(CircleObject prefab, Vector2 point)
    {
        var instance = GameObject.Instantiate(prefab);
        instance.name = prefab.name;
        instance.transform.parent = GameObject.Find("SortObjects").transform;
        instance.gameObject.SetActive(true);
        instance.Position = point;
        instance.transform.position = new Vector2(point.x, point.y * Config.Instance.VerticalScale);
    }
}
