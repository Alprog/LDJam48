
#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AspectChanger))]
public class AspectChangerEditor : Editor
{
    public static string[] AspectPresets = new string[] { "Custom", "5:4", "4:3", "16:10", "16:9", "2:1", "43:18" };
    public int SelectedIndex = 0;

    public AspectChanger Target
    {
        get
        {
            return base.target as AspectChanger;
        }
    }

    protected void OnEnable()
    {
        if (Target != null)
        {
            RefreshPresetName();                
        }
    }

    public void RefreshPresetName()
    {
        var current = Target.AspectRatio;
        for (int i = 1; i < AspectPresets.Length; i++)
        {
            var value = ParseAspectRatio(AspectPresets[i]);
            if (current == value)
            {
                SelectedIndex = i;
                return;
            }
        }
        SelectedIndex = 0;
    }

    public override void OnInspectorGUI()
    {
        //Layout.ComboBox("Presets", AspectPresets, SelectedIndex, OnPresetChanged);

        var value = Target.AspectRatio;
        var newValue = EditorGUILayout.Slider(value, 5.0f / 4.0f, 43.0f / 18.0f);
        if (value != newValue)
        {
            Target.AspectRatio = newValue;
            RefreshPresetName();
        }

        var rectTransform = Target.GetComponent<RectTransform>();
        var width = EditorGUILayout.FloatField("Width", rectTransform.sizeDelta.x);
        var height = EditorGUILayout.FloatField("Height", rectTransform.sizeDelta.y);
        var newSize = new Vector2(width, height);
        if (rectTransform.sizeDelta != newSize)
        {
            rectTransform.sizeDelta = newSize;
            RefreshPresetName();
        }
    }

    public void OnPresetChanged(int index)
    {
        if (index > 0)
        {
            var presetName = AspectPresets[index];
            Target.AspectRatio = ParseAspectRatio(presetName);
        }
        SelectedIndex = index;
    }

    public float ParseAspectRatio(string presetName)
    {
        var arr = presetName.Split(':');
        //Utils.Assert(arr.Length == 2);
        var width = float.Parse(arr[0]);
        var height = float.Parse(arr[1]);
        return width / height;
    }
}

#endif