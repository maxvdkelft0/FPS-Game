using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private Transform player;
    public float attackRange = 10f;

    private enemy enemyScript;
    private PlayerHealth playerHealth; // Reference to the PlayerHealth script

    public Material defaultmaterial;
    public Material alertmaterial;
    public Renderer ren;
    public bool foundPlayer = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = GetComponent<enemy>();
        ren = GetComponent<Renderer>();

        // Get the PlayerHealth script component
        playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth script not found on the player GameObject.");
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            ren.sharedMaterial = alertmaterial; // change material
            enemyScript.badGuy.SetDestination(player.position); // set destination to player position
            foundPlayer = true; // enable bool for chasing

            // Call TakeDamage from PlayerHealth when the enemy is in attack range
            playerHealth.TakeDamage();
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultmaterial; // change material
            enemyScript.NewLocation(); // get new location
            foundPlayer = false; // disable bool for chasing
        }
    }
}
