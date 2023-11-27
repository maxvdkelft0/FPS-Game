using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent badGuy;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    public float squareOfMovement = 20f;
    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float closeEnough = 3f;

    void Start()
    {
        xMin = zMin = -squareOfMovement;
        xMax = zMax = squareOfMovement;
        NewLocation();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            NewLocation();
        }
    }

    public void NewLocation() // get a random location and set it to the enemy
    {
        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        badGuy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
