using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject ZombieComun;
    public GameObject ZombieFast;
    public GameObject ZombieLento;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public Text pauseText;
    public Text scoreText;
    public Text gameOverTxt;

    int score;
    bool pauseActive;
    int rand;

    void Start()
    {
        StartCoroutine(spawnProcess());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*
            if (Time.timeScale == 0){
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }*/
            pauseActive = !pauseActive;
            pauseText.enabled = pauseActive;
            Time.timeScale = (pauseActive) ? 0 : 1.0f;
        }
    }

    public void gameOver()
    {
        gameOverTxt.enabled = true;
        StartCoroutine(gameOverProces());
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Zombies Killed: " + score;
    }

    IEnumerator spawnProcess()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(10.0f);
            rand = Random.Range(1, 4);
            if (rand == 1)
            {
                Instantiate(ZombieComun, spawnPoint1.transform.position, Quaternion.identity);
            }
            else if (rand == 2)
            {
                Instantiate(ZombieFast, spawnPoint1.transform.position, Quaternion.identity);
            }
            else if (rand == 3)
            {
                Instantiate(ZombieLento, spawnPoint1.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("La cagaste we xDXdXD");
            }


            rand = Random.Range(1, 4);
            if (rand == 1)
            {
                Instantiate(ZombieComun, spawnPoint2.transform.position, Quaternion.identity);
            }
            else if (rand == 2)
            {
                Instantiate(ZombieFast, spawnPoint2.transform.position, Quaternion.identity);
            }
            else if (rand == 3)
            {
                Instantiate(ZombieLento, spawnPoint2.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("La cagaste we xDXdXD x2");
            }

            rand = Random.Range(1, 4);
            if (rand == 1)
            {
                Instantiate(ZombieComun, spawnPoint3.transform.position, Quaternion.identity);
            }
            else if (rand == 2)
            {
                Instantiate(ZombieFast, spawnPoint3.transform.position, Quaternion.identity);
            }
            else if (rand == 3)
            {
                Instantiate(ZombieLento, spawnPoint3.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("La cagaste we xDXdXD x3");
            }

            rand = Random.Range(1, 4);
            if (rand == 1)
            {
                Instantiate(ZombieComun, spawnPoint4.transform.position, Quaternion.identity);
            }
            else if (rand == 2)
            {
                Instantiate(ZombieFast, spawnPoint4.transform.position, Quaternion.identity);
            }
            else if (rand == 3)
            {
                Instantiate(ZombieLento, spawnPoint4.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("La cagaste we xDXdXD x4");
            }
        }
    }

    IEnumerator gameOverProces()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Menu");
    }
}
