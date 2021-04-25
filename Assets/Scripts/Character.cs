
public class Character : CircleObject
{
    public Animation BodyAnimation;

    public override void Start()
    {
        base.Start();
        BodyAnimation = GetComponentInChildren<Animation>();
    }
}
