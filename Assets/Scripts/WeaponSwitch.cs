using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    // Camera control
    public GameObject camera_;
    public float distance = 40f;

    private List<GameObject> currentWeapons = new List<GameObject>();

    // Weapon Control
    private int weaponSwitch = 0;
    private int currentWeapon = 0;

    private void Update()
    {
        // Pick Up & Drop
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();

        if (currentWeapons.Count <= 0)
            return;

        // Control Weapon with mouse scroll
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSwitch >= currentWeapons.Count - 1)
                weaponSwitch = 0;
            else
                weaponSwitch++;

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSwitch <= 0)
                weaponSwitch = currentWeapons.Count - 1;
            else
                weaponSwitch--;
        }

        // Control Weapon with number pad
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentWeapons.Count >= 1)
            weaponSwitch = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeapons.Count >= 2)
            weaponSwitch = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentWeapons.Count >= 3)
           weaponSwitch = 2;
    }

    private void ChangeArm()
    {
        if (currentWeapon != weaponSwitch)
            SelectWeapon();
    }

    private void SelectWeapon()
    {
        if (currentWeapons.Count > 0 && currentWeapons[currentWeapon] != null)
            currentWeapons[currentWeapon].SetActive(false);
        currentWeapon = weaponSwitch;
        currentWeapons[currentWeapon].SetActive(true);
    }

    private void PickUp()
    {
        if (Physics.Raycast(camera_.transform.position, camera_.transform.forward, out RaycastHit hit, distance))
        {
            if (hit.transform.CompareTag("Weapon"))
            {
                var _currentWeapon = hit.transform;
                _currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                _currentWeapon.GetComponent<Collider>().isTrigger = true;
                _currentWeapon.parent = transform;
                _currentWeapon.localPosition = Vector3.zero;
                _currentWeapon.localEulerAngles = new Vector3(10f, 0f, 0f);

                if (currentWeapons.Count > 0 && currentWeapons[currentWeapon] != null)
                    weaponSwitch++;
                else
                    weaponSwitch = 0;

                currentWeapons.Add(_currentWeapon.gameObject);
                SelectWeapon();
            }
        }
    }

    void Drop()
    {
        if (currentWeapons.Count <= 0)
            return;

        var _currentWeapon = currentWeapons[currentWeapon];
        _currentWeapon.transform.parent = null;
        _currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        _currentWeapon.GetComponent<Collider>().isTrigger = false;

        currentWeapons.RemoveAt(currentWeapon);

        if (currentWeapons.Count > 0)
            currentWeapon--;
        else
            currentWeapon = 0;

        if (currentWeapons[currentWeapon] != null)
            currentWeapons[currentWeapon].SetActive(true);
    }
}