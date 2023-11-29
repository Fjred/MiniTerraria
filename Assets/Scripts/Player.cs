using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public SpriteRenderer playerSprite;

    public float moveSpeed;

    public float maxHp = 100f;

    public float hp;

    public TMP_Text hpText;

    public Transform healthBar;

    public SpriteRenderer swordSprite;

    public GameObject sword;

    public AudioSource damageTaken;
    void Start()
    {
        hp = maxHp;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (h != 0)
        {
            playerSprite.flipX = h < 0;
            swordSprite.flipX = h < 0;
            float xOffset = (h < 0) ? -0.65f : 0.65f;
            sword.transform.position = new Vector3(transform.position.x + xOffset, sword.transform.position.y, sword.transform.position.z);
        }
        else
        {
            float lastDirection = (playerSprite.flipX) ? -0.65f : 0.65f;
            sword.transform.position = new Vector3(transform.position.x + lastDirection, sword.transform.position.y, sword.transform.position.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageTaken.Play();
            var damage = Random.Range(5, 10);

            hp -= damage;

            hpText.text = $"{hp}";

            healthBar.localScale = new Vector3((float)hp / maxHp, 1, 1);

            if(hp < 0)
            {
                SceneManager.LoadScene(0);
            }

        }
    }

}
