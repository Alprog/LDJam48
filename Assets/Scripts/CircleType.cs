
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
    public static bool IsOccupation(this CircleType type)
    {
        switch (type)
        {
            case CircleType.Resource:
            case CircleType.Bullet:
                return false;

            default:
                return true;
        }
    }
}
