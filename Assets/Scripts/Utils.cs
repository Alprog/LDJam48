
using UnityEngine;

class Utils
{
    public static void RefreshEditors()
    {
        var editors = Resources.FindObjectsOfTypeAll<UnityEditor.Editor>();
        foreach (var editor in editors)
        {
            editor.Repaint();
        }

        var windows = Resources.FindObjectsOfTypeAll<UnityEditor.EditorWindow>();
        foreach (var window in windows)
        {
            window.Repaint();
        }
    }
}
