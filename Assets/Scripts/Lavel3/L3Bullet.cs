using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Bullet : MonoBehaviour
{
    public float speed = 5f;
    private L3PointManager pointManager;
    public GameObject explosion;  // Aggiungi un campo per il prefab dell'esplosione
    public int damage = 1; // Danno inflitto dal proiettile impostato a 1

    // Start is called prima che iniziamo il frame
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<L3PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionB)
    {
        if (collisionB.gameObject.tag == "Enemy")
        {
            pointManager.UpdateScore(50);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);  // Instanzia l'esplosione
            Destroy(exp, 0.4f);  // Distruggi l'esplosione dopo 0.4 secondi

            // Riduci la salute del nemico
            EnemyScript enemy = collisionB.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Danno inflitto: " + damage + ". Salute corrente del nemico: " + enemy.GetCurrentHealth());
            }

            Destroy(gameObject);
        }
        else if (collisionB.gameObject.tag == "Electro")
        {
            Destroy(gameObject);
        }
    }
}
