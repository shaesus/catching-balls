using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    [SerializeField] private float spawnCooldown = 3f;
    private float _gravityScale = 1f;

    private Slopes[] _slopes;

    private void Start()
    {
        _slopes = FindObjectsOfType<Slopes>();
        
        StartCoroutine(SpawnBalls());
    }

    private IEnumerator SpawnBalls()
    {
        yield return new WaitForSeconds(spawnCooldown);
        
        while (true)
        {
            int randomSlopes = Random.Range(0, _slopes.Length);
            int randomSpawnPoint = Random.Range(0, _slopes[randomSlopes].ballSpawnPoints.Length);

            var spawnPoint = _slopes[randomSlopes].ballSpawnPoints[randomSpawnPoint];

            var ball = Instantiate(ballPrefab, spawnPoint.position, quaternion.identity);
            ball.GetComponent<Rigidbody2D>().gravityScale = _gravityScale;

            _gravityScale += 0.1f;
            if (_gravityScale >= 5f)
            {
                _gravityScale = 5f;
            }

            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
