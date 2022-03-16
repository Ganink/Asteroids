using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnCollisionEnter2D (Collision2D collision) {
        Destroy(this.gameObject);
        if (collision.collider.gameObject.GetComponent<Asteroid>()) {
            InstantiatorHelper.CreateExplosionFVX(collision.gameObject.transform);
            PlayerPrefsData.SetScore(PlayerPrefsData.GetScore() + 10);
            Destroy(collision.gameObject);
            Debug.Log("Destroy Asteroid");
        }
    }
}
