using System;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed = 5f;
    
    void Update()
    {
        transform.position += Vector3.left * (_movingSpeed * Time.deltaTime);
    }

    void OnDestroy()
    {
        Debug.Log("Obstacle destroyed");
    }

    public void SetMovingSpeed(float speed)
    {
        _movingSpeed = speed;
    }
}