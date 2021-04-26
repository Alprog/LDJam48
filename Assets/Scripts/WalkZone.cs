
using UnityEngine;

public class WalkZone : MonoBehaviour
{
    public static WalkZone Instance;

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
        var rectTransform = GetComponent<RectTransform>();
        var x = Random.Range(MinX + radius, MaxX - radius);
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

    public bool CollideAny(CircleObject circle)
    {
        return CollideAny(circle.Position, circle.Radius, circle);
    }

    public bool CollideAny(Vector2 position, float radius, CircleObject except)
    {
        foreach (var circle in CircleObject.All)
        {
            if (circle != except)
            {
                if (circle.Type.IsOccupation())
                {
                    var distance = (position - circle.Position).magnitude;
                    if (distance < radius + circle.Radius)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
