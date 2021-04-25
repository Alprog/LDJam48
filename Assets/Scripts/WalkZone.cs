
using UnityEngine;

public class WalkZone : MonoBehaviour
{
    public static WalkZone Instance;

    public void Start()
    {
        Instance = this;
    }
}
