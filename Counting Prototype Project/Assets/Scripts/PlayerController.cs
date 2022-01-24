using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private int count;
    [SerializeField] float zRange;
    private float destroyDelay = 0.2f;
    [SerializeField] float yRange;
    [SerializeField] AudioClip pointSound; 
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Food") && other.transform.position.y > yRange)
        {
            count++;
            gameObject.GetComponent<AudioSource>().PlayOneShot(pointSound); 
            Destroy(other.gameObject, destroyDelay); 
        }
    }

    private void MovePlayer()
    {
        gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
    }

    private void RestrictPlayerMovement()
    {
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
