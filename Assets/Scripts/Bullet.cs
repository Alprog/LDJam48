
using UnityEngine;

public class Bullet : CircleObject
{
    public float Speed;
    public float DelayTime = 0.1f;
    public Vector2 Direction;
    public float CollideDamage;
    
    public override void PerformLogic()
    {
        Velocity = Direction * Speed;

        var collider = WalkZone.Instance.GetCollider(Position, Radius, this, BulletFilter);
        if (collider != null)
        {
            Health = 0;
            if (collider as Enemy)
            {
                collider.Damage(CollideDamage);
            }
        }

        if (!WalkZone.Instance.Contains(Position, Radius))
        {
            Health = 0;
        }
    }

    private bool BulletFilter(CircleObject circle)
    {
        return circle.Health > 0 && !circle.Type.IsPassable() && circle.Type != CircleType.Hero;
    }
}
