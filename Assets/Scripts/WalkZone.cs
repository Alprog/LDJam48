﻿
using UnityEngine;

public class WalkZone : MonoBehaviour
{
    public bool Obstacle;

    public bool TestPoint(Vector2 point)
    {
        bool contains = Contains(point);
        return contains != Obstacle;
    }

    public bool Contains(Vector2 point)
    {
        return false;
    }
}