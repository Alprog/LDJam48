
using UnityEngine;
using UnityEngine.UI;

public class CircleObject : MonoBehaviour
{
    
    public static float Inertness = 1; // time to full stop 
   
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

    public virtual void LateUpdate()
    {
        transform.position = new Vector3(Position.x, Position.y * Config.Instance.VerticalScale, 0);
    }

    public virtual void CalculateSteeringForce(CircleObject[] circleObjects)
    {
        SteeringForce = Vector2.zero;
    }

    public void ApplyMotion()
    {
        SteeringForce *= Random.Range(0.95f, 1.05f);

        Velocity = (Velocity + SteeringForce * Time.deltaTime).Truncate(Config.Instance.MaxEnemySpeed);
        Position += Velocity * Time.deltaTime;
    }
}
