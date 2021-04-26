
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

    public static bool IsInteractive(this CircleType type)
    {
        switch (type)
        {
            case CircleType.Gnome:
            case CircleType.DrillCar:
            case CircleType.Resource:
                return true;

            default:
                return false;
        }
    }
}
