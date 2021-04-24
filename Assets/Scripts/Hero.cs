
using UnityEngine;

public class Hero : MonoBehaviour
{
    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        var direction = Vector3.zero;
        if (Input.GetKey(KeyCode.D)) direction.x += 1;
        if (Input.GetKey(KeyCode.A)) direction.x -= 1;
        if (Input.GetKey(KeyCode.W)) direction.y += 1;
        if (Input.GetKey(KeyCode.S)) direction.y -= 1;

        if (direction != Vector3.zero)
        {
            transform.position += direction * Time.deltaTime * Config.Instance.HeroSpeed;
        }
    }
}
