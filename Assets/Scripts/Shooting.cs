using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject jetBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float bulletSpawnTime = 0.5f;
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
        DetectTouchAndFire();
    }

    void Fire()
    {
        flash.SetActive(true);
        Instantiate(jetBullet, spawnPoint1.position, Quaternion.identity);
        Instantiate(jetBullet, spawnPoint2.position, Quaternion.identity);
        Invoke("DisableFlash", 0.1f); // Disattiva il flash dopo un breve intervallo
    }

    void DetectTouchAndFire()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Fire();
            }
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
        }
    }

    void DisableFlash()
    {
        flash.SetActive(false);
    }
}
