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

    private float xPosition;
    private float yPosition;
    private float zPosition;

    void Start()
    {
        NewLocation();
    }

    void Update()
    {
        
    }

    public void NewLocation()
    {
        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        badGuy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
