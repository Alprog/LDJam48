

using UnityEngine;

public class Enemy : Character
{
    public EnemyConfig EnemyConfig;

    public override void Start()
    {
        base.Start();
        BodyAnimation.Sheet = Config.Instance.EnemyRunSheet;
    }

    public override void CalculateVelocity()
    {
        var config = Config.Instance;

        var seekForce = Vector2.zero;
        var separationForce = Vector2.zero;

        foreach (var circle in CircleObject.All)
        {
            if (circle == this)
            {
                // nothing
            }
            else
            {
                var delta = this.Position - circle.Position;
                var distance = delta.magnitude - Radius - circle.Radius;
                distance = Mathf.Max(0, distance);
                separationForce += GetAvoidForce(delta, distance);

                if (circle.Type == CircleType.Hero)
                {
                    var targetPosition = circle.Position;
                    var desiredVelocity = (targetPosition - Position).normalized * EnemyConfig.MaxSpeed;
                    seekForce = desiredVelocity - Velocity;

                    seekForce = seekForce.Truncate(EnemyConfig.SeekForce);
                    seekForce /= EnemyConfig.Mass;
                }
            }
        }

        SteeringForce = seekForce + separationForce;
        SteeringForce *= Random.Range(0.95f, 1.05f);
        Velocity = (Velocity + SteeringForce * Time.deltaTime).Truncate(EnemyConfig.MaxSpeed);
    }

    public Vector2 GetAvoidForce(Vector2 direction, float distance)
    {
        if (distance < EnemyConfig.AvoidDistance)
        {
            var r = distance / EnemyConfig.AvoidDistance;
            return direction.normalized * Mathf.Lerp(EnemyConfig.AvoidForce, 0, r * r);
        }
        return Vector2.zero;
    }
}
