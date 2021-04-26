
using UnityEngine;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Data.Gold >= 5)
            {
                Data.Gold -= 5;
                Data.RMBShots += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Data.Gold >= 20)
            {
                Data.Gold -= 20;
                Data.Coal += 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Data.Gold >= 30 && Data.Health < 100)
            {
                Data.Gold -= 30;
                Data.Health = 100;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Data.Gold >= 100)
            {
                Data.Gold -= 100;
                Data.GnomeDatas.Add(new GnomeData(100));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("CombatScene");
        }
    }
}
