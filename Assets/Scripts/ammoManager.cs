using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ammoManager : MonoBehaviour
{
    public int maxAmmo = 10;
    private int currentAmmo;

    public TextMeshProUGUI ammoText; // Reference to the Text component
    public TextMeshProUGUI reloadingText; // Reference to the reloading Text component

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

    public void SetReloadingText(string text)
    {
        if (reloadingText != null)
        {
            reloadingText.text = text;
        }
    }

    void UpdateAmmoUI()
    {
        // Update the UI Text with the current ammo count
        if (ammoText != null)
        {
            ammoText.text = currentAmmo.ToString() + "/10";
        }
    }
}
