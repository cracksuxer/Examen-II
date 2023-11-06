using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderB : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Transform currentTarget;

    private void Start()
    {
        currentTarget = (Random.value > 0.5f) ? pointA : pointB;
    }

    void Update()
    {
        if (pointB == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, 1f * Time.deltaTime);
        if (transform.position == currentTarget.position)
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
    }
}
