using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    private RectTransform Canvas;

    void Start()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        GetComponent<Camera>().orthographicSize = Canvas.sizeDelta.y / 2;
    }
}
