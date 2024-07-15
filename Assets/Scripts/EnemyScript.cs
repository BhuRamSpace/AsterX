using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float minX = -1f; // Posizione minima orizzontale
    public float maxX = 1f;  // Posizione massima orizzontale
    public float horizontalSpeed = 2.0f; // Velocità orizzontale
    public GameObject explosion;

    public Transform newBullet1;
    public Transform newBullet2;
    public Transform newBullet3;
    public GameObject enemyBullet;
    public GameObject enemyBullet2;
    public GameController gameController;

    private Transform myTransform;
    private float targetPositionX;
    private bool lastFiredLeft = true;

    public int maxHealth = 100;
    private int currentHealth;
    public HealthBarScript healthBar;

    public GameObject levelComplete;
    public GameObject pauseButton;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        targetPositionX = myTransform.position.x; // Inizializza con la posizione corrente
        StartCoroutine(ChangeDirectionRoutine());
        StartCoroutine(EnemyShooting());
        StartCoroutine(EnemySpecialShooting());

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento orizzontale verso la destinazione
        float newX = Mathf.MoveTowards(myTransform.position.x, targetPositionX, horizontalSpeed * Time.deltaTime);
        myTransform.position = new Vector3(newX, myTransform.position.y, myTransform.position.z);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Danno ricevuto: " + damage); // Aggiungi un messaggio di debug per il danno ricevuto
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        // Aggiungi logica di morte (es. effetto di esplosione, rimuovere il nemico dalla scena, ecc.)
        GameObject exp = Instantiate(explosion, myTransform.position, Quaternion.identity);
        Destroy(exp, 0.4f); // Distruggi l'esplosione dopo 0.4 secondi
        Destroy(gameObject); // Distruggi il nemico

        Time.timeScale = 0f; // Pausa il tempo di gioco
        levelComplete.SetActive(true);
        pauseButton.SetActive(false);
        FindObjectOfType<L3PointManager>().SubmitScoreToPlayFab();
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            // Cambia la destinazione orizzontale a intervalli casuali tra 1 e 3 secondi
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
            targetPositionX = Random.Range(minX, maxX);
        }
    }

    void EnemyFire()
    {
        if (lastFiredLeft)
        {
            Instantiate(enemyBullet, newBullet1.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyBullet, newBullet2.position, Quaternion.identity);
        }
        lastFiredLeft = !lastFiredLeft; // Alterna tra destra e sinistra
    }

    void SpecialFire()
    {
        Debug.Log("Firing special bullet...");
        Instantiate(enemyBullet2, newBullet3.position, Quaternion.identity);
    }

    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            EnemyFire();
        }
    }

    IEnumerator EnemySpecialShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            SpecialFire();
        }
    }
}
