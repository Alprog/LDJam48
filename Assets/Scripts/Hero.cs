﻿
using UnityEngine;

public class Hero : Character
{
    public static Hero Instance;

    public Vector2 Direction = Vector2.right;
    public bool XMirror = false;

    public override void Start()
    {
        base.Start();
        Instance = this;
        BodyAnimation.Sheet = Config.Instance.WhiteIdleSheet;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        BodyAnimation.GetComponent<RectTransform>().localScale = new Vector3(XMirror ? -1 : 1, 1, 1);
    }

    public override void CalculateVelocity()
    {
        var direction = Vector2.zero;
        if (Input.GetKey(KeyCode.D)) direction.x += 1;
        if (Input.GetKey(KeyCode.A)) direction.x -= 1;
        if (Input.GetKey(KeyCode.W)) direction.y += 1;
        if (Input.GetKey(KeyCode.S)) direction.y -= 1;
        if (direction != Vector2.zero)
        {
            this.Direction = direction;
            if (direction.x != 0)
            {
                XMirror = direction.x < 0;
            }
        }
        Velocity = direction * Config.Instance.HeroSpeed;
    }

    public override void ApplyMotion()
    {
        var position = Position + Velocity * Time.deltaTime;
        if (TestPosition(position))
        {
            Position = position;
        }
    }

    public bool TestPosition(Vector2 position)
    {
        if (!WalkZone.Instance.Contains(position, Radius))
        {
            return false;
        }

        return true;
    }
}
