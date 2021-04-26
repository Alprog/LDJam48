
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleObject : MonoBehaviour
{
    public static List<CircleObject> All = new List<CircleObject>();

    public static float Inertness = 1; // time to full stop 

    public CircleType Type;

    public float Health;
    public float Radius;
    public Vector2 Position;
    public Vector2 Velocity;
    public bool HasShadow = true;

    protected Vector2 SteeringForce;

    private Shadow Shadow;
    
    public virtual void Init()
    {
        Shadow = new GameObject("Gizmo").AddComponent<Shadow>();
        Shadow.transform.SetParent(GameObject.Find("Shadows").transform);
        Shadow.SetCircleObject(this);
        All.Add(this);
    }

    public void Damage(float value)
    {
        this.Health -= value;
    }

    public virtual void Die()
    {
        All.Remove(this);
        if (Shadow != null)
        {
            GameObject.Destroy(Shadow.gameObject);
        }
        GameObject.Destroy(gameObject);
    }

    public virtual void FixedUpdate()
    {
        transform.position = new Vector3(Position.x, Position.y * Config.Instance.VerticalScale, 0);
    }

    public virtual void PerformLogic()
    {
        SteeringForce = Vector2.zero;
    }

    public virtual void ApplyMotion()
    {
        Position += Velocity * Time.deltaTime;
    }

    public void SpawnCorpse(Sprite sprite)
    {
        var corpse = new GameObject("Gizmo").AddComponent<Image>();
        corpse.sprite = sprite;
        corpse.transform.SetParent(GameObject.Find("Corpses").transform);
        corpse.transform.position = transform.position;
        corpse.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 2) * Radius;
    }

    public bool IsCurrentInteractiveObject => Hero.Instance != null && Hero.Instance.InteractiveObject == this;
}
