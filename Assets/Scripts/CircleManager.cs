
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    void FixedUpdate()
    {
        foreach (var circle in CircleObject.All)
        {
            circle.PerformLogic();
        }
        for (int i = CircleObject.All.Count - 1; i >= 0; i--)
        {
            if (CircleObject.All[i].Health <= 0)
            {
                CircleObject.All[i].Die();
            }
        }
        foreach (var circle in CircleObject.All)
        {
            circle.ApplyMotion();
        }
    }
}
