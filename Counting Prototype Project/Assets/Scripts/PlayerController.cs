using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private int count;
    public float xRange = 5;
    public float zRange = 5;
    private float destroyDelay = 0.2f;
    private float yRange = 0.5f; 

    public int Count 
    {
        get { return count; } 
        private set { count = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RestrictPlayerMovement(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.position.y > yRange)
        {
            if (collision.gameObject.CompareTag("Food"))
            {
                count++;
            }

            if (collision.gameObject.CompareTag("Bomb"))
            {
                count--;
            }

            Destroy(collision.gameObject, destroyDelay); 
        }
    }

    private void MovePlayer()
    {
        gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
    }

    private void RestrictPlayerMovement()
    {
        if(gameObject.transform.position.x < -xRange)
        {
            gameObject.transform.position = new Vector3(-xRange, gameObject.transform.position.y, gameObject.transform.position.z); 
        }

        if (gameObject.transform.position.x > xRange)
        {
            gameObject.transform.position = new Vector3(xRange, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.z < -zRange)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -zRange);
        }

        if (gameObject.transform.position.z > zRange)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zRange);
        }
    }
}
