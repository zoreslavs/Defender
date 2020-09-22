using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public int curWeaponIndex = 0;

    private int lastWeaponIndex;

    void Start()
    {
        lastWeaponIndex = transform.childCount - 1;

        SelectWeapon();
    }

    void Update()
    {
        CheckKeyboard();
    }

    private void CheckKeyboard()
    {
        int prevWeaponIndex = curWeaponIndex;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (curWeaponIndex >= lastWeaponIndex)
                curWeaponIndex = 0;
            else
                curWeaponIndex++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (curWeaponIndex <= 0)
                curWeaponIndex = lastWeaponIndex;
            else
                curWeaponIndex--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curWeaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curWeaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curWeaponIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curWeaponIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            curWeaponIndex = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            curWeaponIndex = 5;
        }

        if (curWeaponIndex != prevWeaponIndex)
            SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            gun.gameObject.SetActive(i == curWeaponIndex);
            i++;
        }
    }
}
