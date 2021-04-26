
public enum CircleType
{
    Hero,
    Gnome,
    Enemy,
    Obstacle,
    Resource,
    DrillCar,
    Bullet
}

public static class CircleTypeExtension
{
    public static bool IsPassable(this CircleType type)
    {
        switch (type)
        {
            case CircleType.Resource:
            case CircleType.Bullet:
                return true;

            default:
                return false;
        }
    }

    public static bool IsTarget(this CircleType type)
    {
        switch (type)
        {
            case CircleType.Hero:
            case CircleType.Gnome:
                return true;

            default:
                return false;
        }
    }
}
