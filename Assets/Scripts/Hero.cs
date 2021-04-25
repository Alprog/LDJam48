
using UnityEngine;

public class Hero : CircleObject
{
    public static Hero Instance;

    public Animation BodyAnimation;
    public Vector2 Direction = Vector2.right;
    public bool XMirror = false;

    public override void Start()
    {
        base.Start();
        Instance = this;

        BodyAnimation = GetComponentInChildren<Animation>();
        BodyAnimation.Sheet = Config.Instance.WhiteIdleSheet;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        BodyAnimation.GetComponent<RectTransform>().localScale = new Vector3(XMirror ? -1 : 1, 1, 1);
    }

    public override void ApplyMotion()
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

        if (direction != Vector2.zero)
        {
            Position += Velocity * Time.deltaTime;
        }
    }
}
