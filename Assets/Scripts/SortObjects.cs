using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortObjects : MonoBehaviour
{
    void Update()
    {
        var list = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            list.Add(transform.GetChild(i));
        }

        list.Sort((a, b) => b.position.y.CompareTo(a.position.y));
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetSiblingIndex(i);
        }
    }
}
