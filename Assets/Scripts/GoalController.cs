using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball"))
        {
            onTriggerEnter.Invoke();
        }
    }
}
