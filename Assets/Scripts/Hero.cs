
using UnityEngine;

public class Hero : CircleObject
{
    public static Hero Instance;

    public override void Start()
    {
        base.Start();
        Instance = this;
    }

    public override void Update()
    {
        base.Update();
        UpdateMovement();
    }

    void UpdateMovement()
    {
        var direction = Vector2.zero;
        if (Input.GetKey(KeyCode.D)) direction.x += 1;
        if (Input.GetKey(KeyCode.A)) direction.x -= 1;
        if (Input.GetKey(KeyCode.W)) direction.y += 1;
        if (Input.GetKey(KeyCode.S)) direction.y -= 1;

        if (direction != Vector2.zero)
        {
            Position += direction * Time.deltaTime * Config.Instance.HeroSpeed;
        }
    }
}
