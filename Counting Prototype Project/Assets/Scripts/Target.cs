using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float xRange = 5;
    private float zRange = 3; 
    private float ySpawnPos = 10; 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0 || 
            gameObject.transform.position.z < -5 || gameObject.transform.position.z > 5 || 
            gameObject.transform.position.x < -xRange || gameObject.transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(0, ySpawnPos, Random.Range(-zRange, zRange)); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); 
    }

}
