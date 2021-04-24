

using UnityEngine;

public class Enemy : CircleObject
{
    public static float SeparateDistance = 100;

    public override void CalculateSteeringForce(CircleObject[] circleObjects)
    {
        var seekForce = Vector2.zero;
        var separationForce = Vector2.zero;

        foreach (var circle in circleObjects)
        {
            if (circle == this)
            {
                // nothing
            }
            else if (circle is Hero)
            {
                var targetPosition = circle.Position;
                var desiredVelocity = (targetPosition - Position).normalized * MaxVelocity;
                seekForce = desiredVelocity - Velocity;
            }
            else if (circle is Enemy)
            {
                var delta = this.Position - circle.Position;
                var distance = delta.magnitude;
                if (distance < SeparateDistance)
                {
                    var r = distance / SeparateDistance;
                    separationForce += delta.normalized * Mathf.Lerp(1000, 0, r * r);
                }
            }
        }

        Debug.Log(seekForce.magnitude + " " + separationForce.magnitude);

        SteeringForce = seekForce + separationForce;
        SteeringForce = SteeringForce.Truncate(MaxForce);
        SteeringForce /= Mass;
    }
}
