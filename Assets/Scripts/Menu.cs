
using System;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI GoldLabel;
    public TextMeshProUGUI CoalLabel;
    public TextMeshProUGUI GnomeLabel;
    public TextMeshProUGUI HealthLabel;
    public TextMeshProUGUI DangerLevelLabel;

    public void FixedUpdate()
    {
        GoldLabel.text = Data.Gold.ToString();
        CoalLabel.text = Data.Coal.ToString();
        GnomeLabel.text = "x" + Data.GnomeDatas.Count;
        if (Hero.Instance != null)
        {
            HealthLabel.text = Mathf.Max(0, Mathf.FloorToInt(Hero.Instance.Health)).ToString();
        }

        var spawnManager = SpawnManager.Instance;
        DangerLevelLabel.text = String.Format("{0}\n{1}", Math.Floor(spawnManager.DangerLevel), Math.Floor(spawnManager.DangerPoints));
    }
}
