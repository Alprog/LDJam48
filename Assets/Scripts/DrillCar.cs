
using UnityEngine;
using UnityEngine.UI;

public class DrillCar : CircleObject
{
    public static float Acceleration = 400;

    public Image OpenedDoor;
    public Image ReadyBoard;

    public override void PerformLogic()
    {
        //Velocity += Vector2.right * Acceleration * Time.deltaTime;
    }
}
