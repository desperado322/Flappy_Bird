using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        if (!GameOver.IsGameStopped)
            transform.position = transform.position + Vector3.left * _speed * Time.fixedDeltaTime;
    }
}