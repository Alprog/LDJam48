
public class Gnome : Character
{
    public override void Start()
    {
        base.Start();
        BodyAnimation.Sheet = Config.Instance.GnomeIdleSheet;
    }
}
