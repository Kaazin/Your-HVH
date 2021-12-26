using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SwitchWeapons : MonoBehaviour
{
    PlayerControls controls;
    InputAction scroll;

    public float scrollValue;

    public PlayerCombat playerCombat;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    private void OnEnable()
    {
        controls.Player.SwitchWeapon.Enable();

        scroll = controls.Player.SwitchWeapon;
        scroll.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //if(scroll.ReadValue<Vector2>().y != 0)
        scrollValue = scroll.ReadValue<Vector2>().y;

        if(scrollValue > 0)
        {
            if (playerCombat.Weapons[0].activeSelf)
            {
                playerCombat.Weapons[2].SetActive(true);
                playerCombat.Weapons[0].SetActive(false);
            }
            else if (playerCombat.Weapons[2].activeSelf)
            {
                playerCombat.Weapons[0].SetActive(true);
                playerCombat.Weapons[2].SetActive(false);
            }
        }

        else if(scrollValue < 0)
        {
            if (playerCombat.Weapons[1].activeSelf)
            {
                playerCombat.Weapons[3].SetActive(true);
                playerCombat.Weapons[1].SetActive(false);
            }
            else if (playerCombat.Weapons[3].activeSelf)
            {
                playerCombat.Weapons[1].SetActive(true);
                playerCombat.Weapons[3].SetActive(false);
            }


        }
    }
}
