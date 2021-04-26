

using UnityEngine;

public class Enemy : Character
{
    public EnemyConfig EnemyConfig;

    public override void Init()
    {
        base.Init();
        Health = EnemyConfig.MaxHealth;
        BodyAnimation.Sheet = Config.Instance.EnemyRunSheet;
    }

    public override void PerformLogic()
    {
        var config = Config.Instance;

        var seekForce = Vector2.zero;
        var separationForce = Vector2.zero;
        var targetPosition = Vector2.zero;
        var targetPriority = Mathf.Infinity;

        foreach (var circle in CircleObject.All)
        {
            if (circle != this && !circle.Type.IsPassable())
            {
                // avoid
                var delta = this.Position - circle.Position;
                var distance = delta.magnitude - Radius - circle.Radius;
                separationForce += GetAvoidForce(delta, distance);

                if (circle.Type.IsTarget())
                {
                    var k = circle.Type == CircleType.Hero ? Config.Instance.HeroPriorityK : 1;
                    var priority = distance / k;
                    if (priority < targetPriority)
                    {
                        targetPosition = circle.Position;
                        targetPriority = priority;
                    }

                    if (distance < EnemyConfig.AttackDistance)
                    {
                        circle.Damage(EnemyConfig.Damage * Time.deltaTime);
                    }
                }
            }
        }

        // avoid walls
        var zone = WalkZone.Instance;
        separationForce += GetAvoidForce(Vector2.right, Position.x - zone.MinX + Radius);
        separationForce += GetAvoidForce(Vector2.left, zone.MaxX - Radius - Position.x);
        separationForce += GetAvoidForce(Vector2.up, Position.y - zone.MinY + Radius);
        separationForce += GetAvoidForce(Vector2.down, zone.MaxY - Radius - Position.y);

        // seek
        var desiredVelocity = (targetPosition - Position).normalized * EnemyConfig.MaxSpeed;
        seekForce = desiredVelocity - Velocity;
        seekForce = seekForce.Truncate(EnemyConfig.SeekForce);
        seekForce /= EnemyConfig.Mass;

        SteeringForce = seekForce + separationForce;
        SteeringForce *= Random.Range(0.95f, 1.05f);
        Velocity = (Velocity + SteeringForce * Time.deltaTime).Truncate(EnemyConfig.MaxSpeed);
    }

    public Vector2 GetAvoidForce(Vector2 direction, float distance)
    {
        distance = Mathf.Max(0, distance);
        if (distance < EnemyConfig.AvoidDistance)
        {
            var r = distance / EnemyConfig.AvoidDistance;
            return direction.normalized * Mathf.Lerp(EnemyConfig.AvoidForce, 0, r * r);
        }
        return Vector2.zero;
    }

    public override void Die()
    {
        SpawnCorpse(Config.Instance.SlimeSprite);
        base.Die();
    }
}
