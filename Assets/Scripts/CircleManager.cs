
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    void FixedUpdate()
    {
        foreach (var circle in CircleObject.All)
        {
            circle.CalculateVelocity();
        }
        foreach (var circle in CircleObject.All)
        {
            circle.ApplyMotion();
        }
    }
}
