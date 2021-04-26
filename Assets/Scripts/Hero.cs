
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    public static Hero Instance;

    public Vector2 WatchDirection = Vector2.right;
    public bool XMirror = false;

    public float ShotDelay = 0;
    public GnomeData GrabbedGnome;
    public CircleObject InteractiveObject;

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
        BodyAnimation.Sheet = GetCurrentSheet();
        CheckShot();
        CheckInteractive();
        ShotDelay -= Time.deltaTime;
    }
  
    private List<Sprite> GetCurrentSheet()
    {
        if (GrabbedGnome != null)
        {
            return Config.Instance.WhiteGrabGnomeSheet;
        }
        else
        {
            return Config.Instance.WhiteIdleSheet;
        }
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

    public void CheckInteractive()
    {
        InteractiveObject = null;
        foreach (var circle in CircleObject.All)
        {
            if (circle != this && circle.Type.IsInteractive())
            {
                var delta = this.Position - circle.Position;
                var distance = delta.magnitude - Radius - circle.Radius;
                if (distance < Config.Instance.InteractiveDistance)
                {
                    InteractiveObject = circle;
                    break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InteractiveObject != null)
            {
                if (InteractiveObject is Gnome gnome)
                {
                    GrabeGnome(gnome);
                }
            }
            else
            {

            }
        }
    }

    private void GrabeGnome(Gnome gnome)
    {
        GrabbedGnome = gnome.ExtractGnomeData();
        gnome.SilentRemove();
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

    public override void Die()
    {
        SpawnCorpse(Config.Instance.BloodSprite);
        base.Die();
    }
}
