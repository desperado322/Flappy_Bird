using UnityEngine;

public class DestroyClouds : MonoBehaviour
{
    private Transform _cloudPosition;
    private void Start()
    {
        _cloudPosition = GetComponent<Transform>();
    }
    private void Update()
    {
        if (_cloudPosition.transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }
}