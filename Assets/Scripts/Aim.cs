
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public float X;
    public float Y;

    public Image Image;

    public void Start()
    {
        Image = GetComponent<Image>();
    }

    public void Update()
    {
        var direction = Hero.Instance.WatchDirection;
        Image.enabled = direction.x == X && direction.y == Y;
    }
}
