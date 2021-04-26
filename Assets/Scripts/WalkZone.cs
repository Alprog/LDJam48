
using UnityEngine;

public class WalkZone : MonoBehaviour
{
    public static WalkZone Instance;

    public static float EnemySpawnDistance = 70;
    private RectTransform RectTransform;

    public void Start()
    {
        Instance = this;
        RectTransform = GetComponent<RectTransform>();
    }

    public float MinX => RectTransform.position.x + RectTransform.rect.xMin;
    public float MaxX => RectTransform.position.x + RectTransform.rect.xMax;
    public float MinY => (RectTransform.position.y + RectTransform.rect.yMin) / Config.Instance.VerticalScale;
    public float MaxY => (RectTransform.position.y + RectTransform.rect.yMax) / Config.Instance.VerticalScale;

    public Vector2 GetRandomPoint(float radius)
    {
        var x = Random.Range(MinX + radius, MaxX - radius);
        var y = Random.Range(MinY + radius, MaxY - radius);
        return new Vector2(x, y);
    }

    public Vector2 GetRandomEnemyPoint(float radius)
    {
        var x = Random.value > 0.5 ? MinX - EnemySpawnDistance : MaxX + EnemySpawnDistance;
        var y = Random.Range(MinY + radius, MaxY - radius);
        return new Vector2(x, y);
    }

    public Vector2 GetDrillPoint()
    {
        return new Vector2(0, MaxY);
    }

    public bool Contains(Vector2 position, float radius)
    {
        if (position.x < MinX + radius) return false;
        if (position.x > MaxX - radius) return false;
        if (position.y < MinY + radius) return false;
        if (position.y > MaxY - radius) return false;
        return true;        
    }

    public bool CollideAny(CircleObject circle, System.Func<CircleObject, bool> filter = null)
    {
        return CollideAny(circle.Position, circle.Radius, circle, filter);
    }

    public bool CollideAny(Vector2 position, float radius, CircleObject except, System.Func<CircleObject, bool> filter = null)
    {
        return GetCollider(position, radius, except, filter) != null;
    }

    public bool GetCollider(CircleObject circle, System.Func<CircleObject, bool> filter = null)
    {
        return GetCollider(circle.Position, circle.Radius, circle, filter);
    }

    public CircleObject GetCollider(Vector2 position, float radius, CircleObject except, System.Func<CircleObject, bool> filter = null)
    {
        foreach (var circle in CircleObject.All)
        {
            if (circle != except)
            {
                if (filter == null || filter(circle))
                {
                    var distance = (position - circle.Position).magnitude;
                    if (distance < radius + circle.Radius)
                    {
                        return circle;
                    }
                }
            }
        }

        return null;
    }
}
