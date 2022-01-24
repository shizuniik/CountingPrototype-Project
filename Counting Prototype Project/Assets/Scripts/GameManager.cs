using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> listItems;
    public GameObject player;
    public Text countText;
    public Text timerText;
    public Text gameOverText; 
    public bool gameOver; 
    private float spawnRate = 2.0f;
    private float timeLeft = 30;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        StartCoroutine(SpawnItems());
        timerText.text = "Time: " + timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < 0)
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
        }

        if (!gameOver)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(timeLeft);

            countText.text = "Count: " + player.GetComponent<PlayerController>().Count.ToString();
        }
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
