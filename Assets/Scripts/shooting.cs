using System.Collections;
using UnityEngine;
using TMPro;

public class shooting : MonoBehaviour
{
    public Camera cam;
    public ammoManager ammoManager;
    public TextMeshProUGUI killCounterText; // Reference to the TextMeshPro text field

    private RaycastHit hit;
    private Ray ray;
    private bool isReloading = false; // Flag to indicate whether reloading is in progress
    private int killCounter = 0; // Counter to keep track of kills

    void Start()
    {
        // Initialize kill counter text
        UpdateKillCounterText();
    }

    void Update()
    {
        if (!isReloading && Input.GetMouseButtonDown(0))
        {
            // Check if there is enough ammo to shoot
            if (ammoManager.GetCurrentAmmo() > 0)
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag.Equals("NPC"))
                    {
                        Destroy(hit.collider.gameObject);
                        ammoManager.DecreaseAmmo(); // Decrease ammo when shooting
                        IncrementKillCounter(); // Increase kill counter when hitting NPC
                        Debug.Log("Hits NPC");
                    }
                }
            }
            else
            {
                StartCoroutine(ReloadAndDelay());
            }
        }

        // Check if the player wants to reload
        if (!isReloading && Input.GetKeyDown(KeyCode.R))
        {
            // Check if ammo is not already at max before allowing reload
            if (ammoManager.GetCurrentAmmo() < ammoManager.maxAmmo)
            {
                StartCoroutine(ReloadAndDelay());
            }
            else
            {
                StartCoroutine(DisplayMaxAmmoMessage());
            }
        }
    }

    void IncrementKillCounter()
    {
        killCounter++;
        UpdateKillCounterText();
    }

    void UpdateKillCounterText()
    {
        // Update the TextMeshPro text field with the current kill count
        if (killCounterText != null)
        {
            killCounterText.text = killCounter.ToString();
        }
    }

    IEnumerator ReloadAndDelay()
    {
        isReloading = true; // Set the reloading flag to true
        ammoManager.SetReloadingText("Reloading..."); // Set reloading text
        yield return new WaitForSeconds(2f); // Add a delay to simulate reloading time
        ammoManager.ReloadAmmo(); // Reload ammo
        ammoManager.SetReloadingText(""); // Clear reloading text after reload
        isReloading = false; // Set the reloading flag to false after reloading is complete
    }

    IEnumerator DisplayMaxAmmoMessage()
    {
        ammoManager.SetReloadingText("Ammo full..");
        yield return new WaitForSeconds(3f); // Display the message for 3 seconds
        ammoManager.SetReloadingText(""); // Clear the message after 3 seconds
    }
}
