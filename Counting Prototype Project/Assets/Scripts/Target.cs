using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float zRange = 8; 
    private float ySpawnPos = 15;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0 )
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
