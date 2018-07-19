using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public void PlusHP()
    {
        if(PlayerController.health < 3)
        {
            HealthPanel.addHearth(PlayerController.health);
            PlayerController.health += 1;
        }
        else
        {
            GM.Instance.point += 10;
        }
    }
}
