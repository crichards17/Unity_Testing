using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform targetTransform;
    public float speed = 7;

    void Update()
    {
        Vector3 dispFromTarget = targetTransform.position - transform.position;
        Vector3 velocity = dispFromTarget.normalized * speed;

        float distanceToTarget = dispFromTarget.magnitude;

        if (distanceToTarget > 1.5f)
        {
        transform.Translate(velocity * Time.deltaTime);
        }
    }
}
