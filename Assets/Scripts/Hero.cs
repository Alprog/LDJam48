﻿
using UnityEngine;

public class Hero : Character
{
    public static Hero Instance;

    public Vector2 WatchDirection = Vector2.right;
    public bool XMirror = false;

    public float ShotDelay = 0;

    public override void Init()
    {
        base.Init();
        Instance = this;
        BodyAnimation.Sheet = Config.Instance.WhiteIdleSheet;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        BodyAnimation.GetComponent<RectTransform>().localScale = new Vector3(XMirror ? -1 : 1, 1, 1);
        CheckShot();
        ShotDelay -= Time.deltaTime;
    }
    
    public void CheckShot()
    {
        if (ShotDelay <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shot(Config.Instance.RedBulletPrefab as Bullet);
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                Shot(Config.Instance.BlueBulletPrefab as Bullet);
            }
        }
    }
    
    public void Shot(Bullet bulletPrefab)
    {
        var semiRange = bulletPrefab.Range / 2 * Mathf.Deg2Rad;
        var baseAngle = Mathf.Atan2(WatchDirection.y, WatchDirection.x);
        var count = bulletPrefab.FractionCount;
        for (int i = 0; i < count; i++)
        {
            var bullet = SpawnManager.Instance.Spawn(bulletPrefab, Position) as Bullet;
            var k = count > 1 ? (float)i / (count - 1) : 1;
            var bulletAngle = Mathf.Lerp(baseAngle - semiRange, baseAngle + semiRange, k);
            bullet.Direction = new Vector2(Mathf.Cos(bulletAngle), Mathf.Sin(bulletAngle));   
        }
        ShotDelay = bulletPrefab.DelayTime;
    }

    public override void PerformLogic()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mousePosition = (Vector2)Hero.Instance.transform.parent.worldToLocalMatrix.MultiplyPoint(worldPosition);
        mousePosition.y /= Config.Instance.VerticalScale;

        var watchDirection = (mousePosition - Position).normalized;
        if (watchDirection != Vector2.zero)
        {
            this.WatchDirection = watchDirection;
            if (watchDirection.x != 0)
            {
                XMirror = watchDirection.x < 0;
            }
        }

        var moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.D)) moveDirection.x += 1;
        if (Input.GetKey(KeyCode.A)) moveDirection.x -= 1;
        if (Input.GetKey(KeyCode.W)) moveDirection.y += 1;
        if (Input.GetKey(KeyCode.S)) moveDirection.y -= 1;
        Velocity = moveDirection * Config.Instance.HeroSpeed;
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
        if (WalkZone.Instance.CollideAny(position, Radius, this, (c) => !c.Type.IsPassable()))
        {
            return false;
        }

        return true;
    }

    public override void Die()
    {
        SpawnCorpse(Config.Instance.BloodSprite);
        base.Die();
    }
}
