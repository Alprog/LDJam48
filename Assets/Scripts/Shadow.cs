
using UnityEngine;
using UnityEngine.UI;

public class Shadow : MonoBehaviour
{
    public CircleObject CircleObject;
    public RectTransform RectTransform;
    public Image Image;

    public void SetCircleObject(CircleObject circleObject)
    {
        this.CircleObject = circleObject;
    }

    public void Start()
    {
        RectTransform = gameObject.AddComponent<RectTransform>();
        Image = gameObject.AddComponent<Image>();
    }

    public void LateUpdate()
    {
        var config = Config.Instance;

        var x = CircleObject.Position.x;
        var y = CircleObject.Position.y * config.VerticalScale;
        transform.position = new Vector3(x, y, 0);
        RectTransform.sizeDelta = new Vector2(2, 2 * config.VerticalScale) * CircleObject.Radius;

        if (config.ShadowMode == ShadowMode.RotatedCircle)
        {
            var rotation = Mathf.Atan2(CircleObject.Velocity.y, CircleObject.Velocity.x);
            RectTransform.localRotation = Quaternion.Euler(0, 0, rotation * Mathf.Rad2Deg);
        }
        else
        {
            RectTransform.localRotation = Quaternion.identity;
        }

        Image.sprite = config.ShadowMode == ShadowMode.Shadows ? config.ShadowSprite : config.CircleSprite;
    }
}
