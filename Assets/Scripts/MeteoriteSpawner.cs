using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject[] met;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMeteore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Meteore()
    {
        int rand = Random.Range(0,met.Length);
        float randxpos = Random.Range(-2f,2f);
        Instantiate(met[rand], new Vector3(randxpos, transform.position.y,transform.position.z), Quaternion.Euler(0,0,90));
    }

    IEnumerator SpawnMeteore()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Meteore();
        }
    }
}
