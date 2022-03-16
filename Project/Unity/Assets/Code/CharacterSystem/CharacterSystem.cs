using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : MonoBehaviour {
    private float rot = 0.0f;
    private Vector2 character;

    private bool isWalkEnable;
    private bool isShieldEnable;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject shieldPrefab;

    [SerializeField] private List<AudioClip> sounds;
    [SerializeField] private AudioSource audioSource;

    void Update () {
        character.x = 0;
        character.y = Input.GetAxis("Vertical");
        RotatePrefab();

        isWalkEnable = Input.GetKey(KeyCode.W);
        isShieldEnable = Input.GetKey(KeyCode.S);


        if (Input.GetButtonDown("Fire1")) {
            audioSource.clip = sounds [0];
            audioSource.Play();
        }
    }

    private void FixedUpdate () {
        CharacterActions();
        LimitsWorld();
    }

    private void CharacterActions () {
        if (isWalkEnable) {
            rb.AddForce(transform.up * Constants.CHARACTER_SPEED);
        } else if (isShieldEnable) {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            shieldPrefab.SetActive(true);
        } else {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            shieldPrefab.SetActive(false);
        }
    }

    private void LimitsWorld () {
        if (this.transform.position.x > 24 || this.transform.position.x < -24) {
            this.transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if (this.transform.position.y > 12 || this.transform.position.y < -12) {
            this.transform.position = new Vector2(transform.position.x, -transform.position.y);
        } 
    }

    private void RotatePrefab () {
        rot -= Input.GetAxis("Horizontal") * Constants.CHARACTER_ROTATION_SPEED;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, rot);
    }
}
