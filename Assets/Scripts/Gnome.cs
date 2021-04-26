
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gnome : Character
{
    public TextMeshProUGUI HealthLabel;
    public Image KeyIcon;

    public override void Init()
    {
        base.Init();
        BodyAnimation.Sheet = Config.Instance.GnomeIdleSheet;
    }

    public void Update()
    {
        HealthLabel.text = Mathf.Max(0, Mathf.FloorToInt(Health)).ToString();
        HealthLabel.color = Color.Lerp(Color.red, Color.green, Health / 100);
        KeyIcon.enabled = IsCurrentInteractiveObject;
    }

    public override void Die()
    {
        SpawnCorpse(Config.Instance.BloodSprite);
        base.Die();        
    }

    public void SilentRemove()
    {
        base.Die();
    }

    public GnomeData ExtractGnomeData()
    {
        return new GnomeData(Health);
    }

    public void SetData(GnomeData data)
    {
        this.Health = data.Health;
    }
}
