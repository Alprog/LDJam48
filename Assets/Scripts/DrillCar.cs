
using UnityEngine;

public class DrillCar : CircleObject
{
    public static float Acceleration = 400;

    public override void PerformLogic()
    {
        //Velocity += Vector2.right * Acceleration * Time.deltaTime;
    }
}
