
public class Character : CircleObject
{
    public Animation BodyAnimation;

    public override void Init()
    {
        base.Init();
        BodyAnimation = GetComponentInChildren<Animation>();
    }
}
