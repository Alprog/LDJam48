
using UnityEngine;
using UnityEngine.UI;

public class CircleObject : MonoBehaviour
{
    public static float MaxVelocity = 300;
    public static float MaxForce = 900;

    public static float MaxSpeed = 300; // pixels per seconds
    public static float Inertness = 1; // time to full stop 
    
    public static float Mass = 3;

    public float Radius;
    public Vector2 Position;
    public Vector2 Velocity;

    protected Vector2 SteeringForce;

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

    public virtual void CalculateSteeringForce(CircleObject[] circleObjects)
    {
        SteeringForce = Vector2.zero;
    }

    public void ApplyMotion()
    {
        Velocity = (Velocity + SteeringForce * Time.deltaTime).Truncate(MaxSpeed);
        Position += Velocity * Time.deltaTime;
    }
}
