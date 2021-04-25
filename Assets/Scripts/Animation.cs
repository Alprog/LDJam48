
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public static int FPS = 10;

    private float CurrentTime = 0;
    private Image Image;

    public List<Sprite> Sheet;

    public void Start()
    {
        Image = GetComponent<Image>();
    }

    public void Update()
    {
        if (Sheet == null)
        {
            return;
        }

        CurrentTime += Time.deltaTime;

        var frameIndex = Mathf.FloorToInt(CurrentTime * FPS) % Sheet.Count;
        Image.sprite = Sheet[frameIndex];
    }
}
