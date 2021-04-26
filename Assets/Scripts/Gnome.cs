
using TMPro;
using UnityEngine;

public class Gnome : Character
{
    public TextMeshProUGUI HealthLabel;

    public override void Init()
    {
        base.Init();
        BodyAnimation.Sheet = Config.Instance.GnomeIdleSheet;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        HealthLabel.text = Mathf.Max(0, Mathf.FloorToInt(Health)).ToString();
        HealthLabel.color = Color.Lerp(Color.red, Color.green, Health / 100);
    }

    public override void Die()
    {
        SpawnCorpse(Config.Instance.BloodSprite);
        base.Die();        
    }
}
