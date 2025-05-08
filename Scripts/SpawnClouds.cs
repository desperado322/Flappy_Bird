using System.Collections;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    [SerializeField] private GameObject[] _clouds = new GameObject[3];

    private float x;

    private void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    private IEnumerator SpawnCloud() 
    {
        while (!GameOver.IsGameStopped)
        {
            _clouds[Random.Range(0, _clouds.Length)].transform.localScale = new Vector3(x = Random.Range(2, 3), x);
            Instantiate(_clouds[Random.Range(0, _clouds.Length)], new Vector2(transform.position.x, Random.Range(-10, 10)), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}