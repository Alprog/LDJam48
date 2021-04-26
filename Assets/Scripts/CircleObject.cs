
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public static List<CircleObject> All = new List<CircleObject>();

    public static float Inertness = 1; // time to full stop 

    public CircleType Type;

    public float Radius;
    public Vector2 Position;
    public Vector2 Velocity;
    public bool HasShadow = true;

    protected Vector2 SteeringForce;

    private Shadow Shadow;
    
    public virtual void Start()
    {
        Shadow = new GameObject("Gizmo").AddComponent<Shadow>();
        Shadow.transform.parent = GameObject.Find("Shadows").transform;
        Shadow.SetCircleObject(this);
        All.Add(this);
    }

    public virtual void FixedUpdate()
    {
        transform.position = new Vector3(Position.x, Position.y * Config.Instance.VerticalScale, 0);
    }

    public virtual void CalculateVelocity()
    {
        SteeringForce = Vector2.zero;
    }

    public virtual void ApplyMotion()
    {
        Position += Velocity * Time.deltaTime;
    }
}
