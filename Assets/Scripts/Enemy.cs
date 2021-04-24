using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CircleObject
{
    public static float MaxVelocity = 300;
    public static float MaxForce = 100;
    public static float MaxSpeed = 300;
    public static float Mass = 100;

    public virtual void FixedUpdate()
    {
        var targetPosition = Hero.Instance.Position;
        var desiredVelocity = (targetPosition - Position).normalized * MaxVelocity;
        var steering = desiredVelocity - Velocity;

        steering = Truncate(steering, MaxVelocity);
        steering /= Mass;

        Velocity = Truncate(Velocity + steering, MaxSpeed);
        Position += Velocity * Time.deltaTime;
    }

    public Vector2 Truncate(Vector2 vector, float maxMagnitude)
    {
        var k = vector.magnitude / maxMagnitude;
        if (k > 1)
        {
            return vector / k;
        }
        return vector;
    }
}
