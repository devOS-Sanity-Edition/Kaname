using FMODUnity;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 15f;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    private SpriteRenderer bulletRenderer;

    void Start() {
        GameColorManager.Theme theme = GameObject.Find("GameColorManager").GetComponent<GameColorManager>().InternalGameTheme;
        gameObject.tag = "Bullet";
        rb.velocity = transform.up * speed;
        bulletRenderer = GetComponent<SpriteRenderer>();
        bulletRenderer.color = ColorHandler.GetColorFromString(theme.GameColors.Bullet);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "DeathBall" || col.gameObject.tag == "DeathRing") { RuntimeManager.PlayOneShot("event:/SFX/Damage"); }
    }
}