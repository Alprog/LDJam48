
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
    public float MinY => RectTransform.position.y + RectTransform.rect.yMin;
    public float MaxY => RectTransform.position.y + RectTransform.rect.yMax;

    public Vector2 GetRandomPoint()
    {
        var rectTransform = GetComponent<RectTransform>();
        var x = Random.Range(MinX, MaxX);
        var y = Random.Range(MinY, MaxY);
        return new Vector2(x, y);
    }
}
