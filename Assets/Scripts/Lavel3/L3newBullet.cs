using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3newBullet : MonoBehaviour
{
    public Transform myTransform;
    public float bulletSpeed = 10.0f; // Rinomina la variabile di velocità
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.position -= transform.up * bulletSpeed * Time.deltaTime;

        // Verifica se il proiettile è uscito dallo schermo
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);  // Instanzia l'esplosione
            Destroy(exp, 0.4f);
        }
    }
}
