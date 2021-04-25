

using UnityEngine;

public class Enemy : CircleObject
{
    public override void CalculateSteeringForce(CircleObject[] circleObjects)
    {
        var config = Config.Instance;

        var seekForce = Vector2.zero;
        var separationForce = Vector2.zero;

        foreach (var circle in circleObjects)
        {
            if (circle == this)
            {
                // nothing
            }
            else
            {
                var delta = this.Position - circle.Position;
                var distance = delta.magnitude;
                if (distance < config.SeparateDistance)
                {
                    var r = distance / config.SeparateDistance;
                    separationForce += delta.normalized * Mathf.Lerp(config.AvoidForce, 0, r * r);
                }

                if (circle is Hero)
                {
                    var targetPosition = circle.Position;
                    var desiredVelocity = (targetPosition - Position).normalized * MaxVelocity;
                    seekForce = desiredVelocity - Velocity;

                    seekForce = seekForce.Truncate(config.SeekForce);
                    seekForce /= Mass;
                }
            }
        }

        SteeringForce = seekForce + separationForce;
        //SteeringForce = SteeringForce.Truncate(MaxForce);
        //SteeringForce /= Mass;
    }
}
