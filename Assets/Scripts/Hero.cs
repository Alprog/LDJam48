
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
                var baseAngle = Mathf.Atan2(WatchDirection.y, WatchDirection.x);
                for (int i = -4; i <= 4; i++)
                {
                    var bullet = SpawnManager.Instance.Spawn(Config.Instance.RedBulletPrefab, Position) as Bullet;
                    var bulletAngle = baseAngle + Mathf.PI / 16 * i;
                    bullet.Direction = new Vector2(Mathf.Cos(bulletAngle), Mathf.Sin(bulletAngle));
                    ShotDelay = bullet.DelayTime;
                }
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                var bullet = SpawnManager.Instance.Spawn(Config.Instance.BlueBulletPrefab, Position) as Bullet;
                bullet.Direction = WatchDirection;
                ShotDelay = bullet.DelayTime;
            }
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

    public override void Die()
    {
        SpawnCorpse(Config.Instance.BloodSprite);
        base.Die();
    }
}
