using System.Collections;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera cam;
    public ammoManager ammoManager;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                        Debug.Log("Hits shit");
                    }
                }
            }
            else
            {
                StartCoroutine(ReloadAndDelay());
            }
        }

        // Check if the player wants to reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadAndDelay());
        }
    }

    IEnumerator ReloadAndDelay()
    {
        Debug.Log("Reloading");
        yield return new WaitForSeconds(2f); // Add a delay to simulate reloading time
        ammoManager.ReloadAmmo(); // Reload ammo
        Debug.Log("Reloaded");
    }
}
