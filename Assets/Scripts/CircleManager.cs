
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    void FixedUpdate()
    {
        var circles = GameObject.FindObjectsOfType<CircleObject>();      
        foreach (var circle in circles)
        {
            circle.CalculateVelocity(circles);
        }
        foreach (var circle in circles)
        {
            circle.ApplyMotion();
        }
    }
}
