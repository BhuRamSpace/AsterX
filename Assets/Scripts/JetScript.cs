using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JetScript : MonoBehaviour
{
    new public Transform transform;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public GameObject explosion;
    public GameController gameController;

    public int maxHealth = 100;
    private int currentHealth;
    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Clamp();
    }

    void Movement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                transform.position += new Vector3(touchDeltaPosition.x * speed * Time.deltaTime, 0, 0);
                if (touchDeltaPosition.x > 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -25), rotationSpeed * Time.deltaTime);
                }
                else if (touchDeltaPosition.x < 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 25), rotationSpeed * Time.deltaTime);
                }
            }
        }

        if (transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10f * Time.deltaTime);
        }
    }

    void Clamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2f, 2f);
        transform.position = pos;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Danno ricevuto: " + damage + ". Salute corrente: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("La scena attuale si chiama:" + currentSceneName);
        if (currentSceneName == "Level1")
        {
            gameController.GameOver();
        }
        else if (currentSceneName == "Level2")
        {
            gameController.L2GameOver();
        }
        else if (currentSceneName == "Level3")
        {
            gameController.L3GameOver();
        }
        Destroy(gameObject);
        GameObject expJet = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(expJet, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meteoriti")
        {
            Debug.Log("Collided with Meteoriti");
            TakeDamage(50);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "L2Meteoriti")
        {
            Debug.Log("Collided with L2Meteoriti");
            TakeDamage(50);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "L3newBullet")
        {
            Debug.Log("Collided with L3newBullet");
            TakeDamage(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SpecialBullet")
        {
            Debug.Log("Collided with SpecialBullet");
            TakeDamage(30);
            Destroy(collision.gameObject);
        }
    }
}
