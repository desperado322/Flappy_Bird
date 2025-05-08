using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _pipesPrefab;

    private void Start()
    {
        StartCoroutine(SpawnPipes());
    }
    private IEnumerator SpawnPipes()
    {
        while (!GameOver.IsGameStopped)
        {
            Instantiate(_pipesPrefab, new Vector3(transform.position.x, Random.Range(-10, 8), transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}