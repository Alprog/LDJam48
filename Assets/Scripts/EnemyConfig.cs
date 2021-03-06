
using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
    public float MaxSpeed = 150;
    public float MaxHealth = 100;
    public float AttackDistance = 15;
    public float Damage = 10;    
    public float Mass = 3;

    public float SeekForce = 150;
    public float AvoidDistance = 50;
    public float AvoidForce = 500;

    public float DangerPrice = 1.0f;
}
