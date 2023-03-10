using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movetopoint : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private NavMeshAgent tut;
    void Start()
    {
        tut.destination = point.transform.position;
    }
    
}
