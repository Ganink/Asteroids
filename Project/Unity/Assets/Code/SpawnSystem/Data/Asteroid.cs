using UnityEngine;

public class Asteroid : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb2d;

    public float size = 1f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;

    private Transform transformHelper;

    private void Start () {
        transformHelper = this.gameObject.transform;
        transformHelper.localScale = Vector3.one * size;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        DestroyAsteroid();
    }

    private void FixedUpdate () {
        LimitsWorld();
    }

    private void DestroyAsteroid () {
        float timeRandom = Random.Range(Constants.ASTEROID_MIN_TIME_DESTROY, Constants.ASTEROID_MAX_TIME_DESTROY);
        Destroy(this.gameObject, timeRandom);
    }

    public void SetMove (Vector2 direction) {
        rb2d.AddForce(direction * Constants.ASTEROID_SPEED);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.gameObject.GetComponent<CharacterSystem>()) {
            LivesManager.ConsumeLife();
            Destroy(collision.gameObject);
        }
    }

    private void LimitsWorld () {
        if (transformHelper.position.x > 23) {
            transformHelper.position = new Vector2(-22, transformHelper.position.y);
        } else if (this.transform.position.x < -23) {
            transformHelper.position = new Vector2(22, transformHelper.position.y);
        }
        if (transformHelper.position.y > 10) {
            transformHelper.position = new Vector2(transformHelper.position.x, -10);
        } else if (this.transform.position.y < -10) {
            transformHelper.position = new Vector2(transformHelper.position.x, 10);
        }
    }
}
