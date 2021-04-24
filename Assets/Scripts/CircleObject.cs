
using UnityEngine;
using UnityEngine.UI;

public class CircleObject : MonoBehaviour
{
    public float Mass;
    public float Radius;
    public Vector2 Position;
    public Vector2 Velocity;

    private Image Gizmo;
    private RectTransform GizmoRectTransform;

    public virtual void Start()
    {
        Position = transform.position;

        Gizmo = new GameObject("Gizmo").AddComponent<Image>();
        Gizmo.transform.parent = transform;
        Gizmo.transform.localPosition = Vector3.zero;
        Gizmo.sprite = Config.Instance.CircleSprite;
        Gizmo.gameObject.AddComponent<RectTransform>();
        GizmoRectTransform = Gizmo.GetComponent<RectTransform>();
    }

    public virtual void Update()
    {
        transform.position = Position;
        GizmoRectTransform.sizeDelta = new Vector2(2, 2) * Radius;

        var rotation = Mathf.Atan2(Velocity.y, Velocity.x);
        Gizmo.transform.localRotation = Quaternion.Euler(0, 0, rotation * Mathf.Rad2Deg);
    }
}
