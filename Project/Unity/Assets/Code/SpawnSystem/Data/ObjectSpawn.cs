using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {
    [Range(0f, 5f)]
    public float randomPosition = 2.5f;
    public float spawnDistance = 5f;
    public bool isBorderLateral = false;

    [SerializeField] private Asteroid asteroidPrefab;

    private void Start () {
        Initialized();
    }

    /*private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider) {
            if (isBorderLateral) {
                collision.collider.transform.position = new Vector2(-collision.collider.transform.position.x, collision.collider.transform.position.y);
            } else {
                collision.collider.transform.position = new Vector2(collision.collider.transform.position.x, -collision.collider.transform.position.y);
            }
        }
    }*/

    private void Initialized () {
        InvokeRepeating("SpawnElements", 1, Constants.ASTEROID_TIME_CREATE);
    }

    public void SpawnElements () {
        if (asteroidPrefab == null) {
            return;
        }

        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPoint = spawnDirection * spawnDistance;

        spawnPoint += transform.position;

        float positionToRotate = Random.Range(-randomPosition, randomPosition);
        Quaternion rotation = Quaternion.AngleAxis(positionToRotate, Vector3.forward);

        Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
        asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

        Vector2 trajectory = rotation * -spawnDirection;
        asteroid.SetMove(trajectory);
    }

}
