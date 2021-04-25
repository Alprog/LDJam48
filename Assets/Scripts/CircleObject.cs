
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public static float Inertness = 1; // time to full stop 

    public CircleType Type;

    public float Radius;
    public Vector2 Position;
    public Vector2 Velocity;

    protected Vector2 SteeringForce;

    private Shadow Shadow;
    
    public virtual void Start()
    {
        Position = transform.position;

        Shadow = new GameObject("Gizmo").AddComponent<Shadow>();
        Shadow.transform.parent = GameObject.Find("Shadows").transform;
        Shadow.SetCircleObject(this);
    }

    public virtual void FixedUpdate()
    {
        transform.position = new Vector3(Position.x, Position.y * Config.Instance.VerticalScale, 0);
    }

    public virtual void CalculateVelocity(CircleObject[] circleObjects)
    {
        SteeringForce = Vector2.zero;
    }

    public virtual void ApplyMotion()
    {
        Position += Velocity * Time.deltaTime;
    }
}
