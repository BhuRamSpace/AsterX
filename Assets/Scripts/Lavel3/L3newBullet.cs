using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3newBullet : MonoBehaviour
{
    public Transform myTransform;
    public float bulletSpeed = 10.0f; // Rinomina la variabile di velocità
    public GameObject explosion;
    private L3PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        pointManager = GameObject.Find("PointManager").GetComponent<L3PointManager>();
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

    private void OnTriggerEnter2D(Collider2D collisionB)
    {
        if (collisionB.gameObject.tag == "Jet")
        {
            Destroy(gameObject);
            GameObject expJet = Instantiate(explosion, myTransform.position, Quaternion.identity);
            Destroy(expJet, 0.4f);
            pointManager.UpdateScore(50);
        }
    }
}
