using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> listItems;
    public GameObject player;
    public Text countText;
    public bool gameOver; 
    private float spawnRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        StartCoroutine(SpawnItems()); 
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "Count: " + player.GetComponent<PlayerController>().Count.ToString();   
    }

    IEnumerator SpawnItems()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(listItems[Random.Range(0, listItems.Count)]);
        }
    }
}
