using TMPro;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace

public class ammoManager : MonoBehaviour
{
    public int maxAmmo = 10;
    private int currentAmmo;

    public TextMeshProUGUI ammoText; // Reference to the Text component


    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void DecreaseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmoUI(); // updates the ui field
        }
    }

    public void ReloadAmmo()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        // Update the UI Text with the current ammo count
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo.ToString();
        }
    }
}
