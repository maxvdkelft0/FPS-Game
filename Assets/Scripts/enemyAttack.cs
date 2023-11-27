using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyAttack : MonoBehaviour
{
    private Transform player;
    public float attackRange = 10f;

    private enemy enemyScript;

    public Material defaultmaterial;
    public Material alertmaterial;
    public Renderer ren;
    public bool foundPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = GetComponent<enemy>();
        ren = GetComponent<Renderer>();
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
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultmaterial; // change material
            enemyScript.NewLocation(); // get new location
            foundPlayer = false; // disbale bool for chasing
        }
    }
}
