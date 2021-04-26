
using UnityEngine.UI;

public class Resource : CircleObject
{
    public bool IsGold;
    public Gnome CurrentGnome;
    public Image KeyIcon;

    public void Update()
    {
        KeyIcon.enabled = IsCurrentInteractiveObject;
    }
}
