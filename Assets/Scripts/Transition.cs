using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }
}
