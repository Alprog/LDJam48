
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI GoldLabel;
    public TextMeshProUGUI CoalLabel;
    public TextMeshProUGUI GnomeLabel;
    public TextMeshProUGUI HealthLabel;

    public void FixedUpdate()
    {
        GoldLabel.text = Data.Gold.ToString();
        CoalLabel.text = Data.Coal.ToString();
        GnomeLabel.text = "x" + Data.GnomeHealths.Count;
        if (Hero.Instance != null)
        {
            HealthLabel.text = Mathf.Max(0, Mathf.FloorToInt(Hero.Instance.Health)).ToString();
        }
    }
}
