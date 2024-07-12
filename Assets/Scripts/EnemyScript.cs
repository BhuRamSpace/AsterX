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

    private Transform myTransform;
    private float targetPositionX;
    private bool lastFiredLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        targetPositionX = myTransform.position.x; // Inizializza con la posizione corrente
        StartCoroutine(ChangeDirectionRoutine());
        StartCoroutine(EnemyShooting());
        StartCoroutine(EnemySpecialShooting());
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento orizzontale verso la destinazione
        float newX = Mathf.MoveTowards(myTransform.position.x, targetPositionX, horizontalSpeed * Time.deltaTime);
        myTransform.position = new Vector3(newX, myTransform.position.y, myTransform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        GameObject expJet = Instantiate(explosion, myTransform.position, Quaternion.identity);
        Destroy(expJet, 0.4f);
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
        while (true) {
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
