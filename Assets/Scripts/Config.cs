
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance;

    public float HeroSpeed = 5;

    public void Start()
    {
        Instance = this;
    }
}
