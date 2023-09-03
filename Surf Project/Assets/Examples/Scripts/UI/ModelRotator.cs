using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotator : MonoBehaviour
{
    [SerializeField] private Transform rotatorTransform;
    [SerializeField] private float speed = 1;

    private void Update()
    {
        rotatorTransform.localRotation = 
            Quaternion.Euler(rotatorTransform.localRotation.eulerAngles + new Vector3(0, speed * Time.deltaTime, 0));
    }
}
