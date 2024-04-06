using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject jetBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float bulletSpawnTime=0.5f;
    public GameObject flash;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            flash.SetActive(true);
            Instantiate(jetBullet, spawnPoint1.position, Quaternion.identity);
            Instantiate(jetBullet, spawnPoint2.position, Quaternion.identity);

        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            flash.SetActive(false);
        }
    }
}
