using System;
using UnityEngine;

namespace Core
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField] public GameObject Target;

        private void Update()
        {
            if (Target != null)
            {
                transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
            }
        }
    }
}