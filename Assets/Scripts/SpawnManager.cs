
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Spawn(Config.Instance.WhiteEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Spawn(Config.Instance.YellowEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Spawn(Config.Instance.RedEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha4)) Spawn(Config.Instance.GreenEnemyPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha5)) Spawn(Config.Instance.ObstaclePrefab);
        if (Input.GetKeyDown(KeyCode.Alpha6)) Spawn(Config.Instance.GnomePrefab);
    }

    public void Start()
    {
        Spawn(Config.Instance.HeroPrefab);
    }

    public void Spawn(CircleObject prefab)
    {
        var point = WalkZone.Instance.GetRandomPoint();

        
        var instance = GameObject.Instantiate(prefab);
        instance.name = prefab.name;
        instance.transform.parent = GameObject.Find("SortObjects").transform;
        instance.gameObject.SetActive(true);

        instance.transform.position = point;
        point.y /= Config.Instance.VerticalScale;
        instance.Position = point;
    }
}
