
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DrillCar : CircleObject
{
    public static float Acceleration = 400;

    public Image OpenedDoor;
    public Image ReadyBoard;

    public Image KeyPut;
    public Image KeyGet;
    public Image KeySpace;

    public bool Moving;

    public void Update()
    {
        ReadyBoard.enabled = IsReady();

        bool selected = IsCurrentInteractiveObject;
        KeyPut.enabled = selected && Hero.Instance.GrabbedGnome != null;
        KeyGet.enabled = selected && Hero.Instance.GrabbedGnome == null && Data.GnomeDatas.Count > 0;
        KeySpace.enabled = selected && IsReady();

        if (Position.x > 800)
        {
            SceneManager.LoadScene("Store");
        }
    }

    public bool IsReady()
    {
        return Data.Coal > Config.Instance.NeedCoal;
    }

    public override void PerformLogic()
    {
        if (Moving)
        {
            Velocity += Vector2.right * Acceleration * Time.deltaTime;
        }
    }

    public void Go()
    {
        Moving = true;
        OpenedDoor.enabled = false;
    }
}
