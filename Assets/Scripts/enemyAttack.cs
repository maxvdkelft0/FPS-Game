using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyAttack : MonoBehaviour
{
    public Transform player;
    public float attackRange = 10f;

    private enemy enemyScript;

    public Material defaultmaterial;
    public Material alertmaterial;
    public Renderer ren;

    private void Awake()
    {
        enemyScript = GetComponent<enemy>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            ren.sharedMaterial = alertmaterial;
            enemyScript.badGuy.SetDestination(player.position);
        }
        else
        {
            ren.sharedMaterial = defaultmaterial;
            enemyScript.NewLocation();
        }
    }
}
