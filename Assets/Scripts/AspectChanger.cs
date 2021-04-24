
using UnityEngine;

public class AspectChanger : MonoBehaviour
{
    public float AspectRatio
    {
        get
        {
            var rectTransform = GetComponent<RectTransform>();
            var width = rectTransform.sizeDelta.x;
            var height = rectTransform.sizeDelta.y;
            return width / height;
        }
        set
        {
            var rectTransform = GetComponent<RectTransform>();
            var width = rectTransform.sizeDelta.x;
            var height = width / value;
            rectTransform.sizeDelta = new Vector2(width, height);
        }
    }

    public void Update()
    {
        AspectRatio = (float)Screen.width / (float)Screen.height;
    }
}