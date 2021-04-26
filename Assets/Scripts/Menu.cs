
using System;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI GoldLabel;
    public TextMeshProUGUI CoalLabel;
    public TextMeshProUGUI GnomeLabel;
    public TextMeshProUGUI HealthLabel;
    public TextMeshProUGUI AmmoLabel;
    public TextMeshProUGUI DangerLevelLabel;

    public void FixedUpdate()
    {
        GoldLabel.text = Mathf.FloorToInt(Data.Gold).ToString();
        CoalLabel.text = Mathf.FloorToInt(Data.Coal).ToString();
        GnomeLabel.text = "x" + Data.GnomeDatas.Count;
        AmmoLabel.text = Data.RMBShots.ToString();
        if (Hero.Instance != null)
        {
            HealthLabel.text = Mathf.Max(0, Mathf.FloorToInt(Hero.Instance.Health)).ToString();
        }

        if (DangerLevelLabel != null)
        {
            var spawnManager = SpawnManager.Instance;
            DangerLevelLabel.text = String.Format("{0}\n{1}", Math.Floor(spawnManager.DangerLevel), Math.Floor(spawnManager.DangerPoints));
        }
    }
}
