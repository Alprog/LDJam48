
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

    public Vector2 GetRandomPoint()
    {
        var rectTransform = GetComponent<RectTransform>();
        var x = Random.Range(MinX, MaxX);
        var y = Random.Range(MinY, MaxY);
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
}
