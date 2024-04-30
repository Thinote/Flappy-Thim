using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isInGame = false;
    int score = 0;
    [SerializeField] TextMesh txtScore;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] AudioClip soundPoint;
    [SerializeField] GameObject flash;
    [SerializeField] TextMesh txtBestScore;

    // Start is called before the first frame update
    void Start()
    {
        txtScore.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        txtBestScore.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        txtScore.text = "";
        gameOverScreen.SetActive(false);
        startScreen.SetActive(true);
        flash.SetActive(false);
        txtBestScore.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isInGame)
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void StartGame()
    {
        Debug.Log("StartGame");
        isInGame = true;
        BroadcastMessage("OnStartGame");
        startScreen.SetActive(false);
        txtScore.text = "0";
        txtBestScore.text = "";




    }

    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();
        GetComponent<AudioSource>().PlayOneShot(soundPoint);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        BroadcastMessage("OnGameOver");
        gameOverScreen.SetActive(true);
        flash.SetActive(true);

        if(score > PlayerPrefs.GetInt("BestScore", score))
        {
            PlayerPrefs.SetInt("BestScore", score);
            txtBestScore.text = "New Best score: " + PlayerPrefs.GetInt("BestScore", score);


        }
        else
        {
            txtBestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore", score);
        }
        
        
    }
}
