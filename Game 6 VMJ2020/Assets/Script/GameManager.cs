using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public bool GameOver = false;
    public GameObject Scoremater, GameOverPanel, InGamePanel;
    public Text ScoreFinal, HighScore;
    public GameObject[] Medal;
    public AudioSource sfx;

    Animator anim;

    void Start()
    {
        anim = Scoremater.GetComponent<Animator>();
    }

    void Update()
    {
        Scoremater.GetComponent<Text>().text = "Score : " + Score.ToString();

        if (Score >= 15)
        {
            medal(1);
        }

        if (Score >= 30)
        {
            medal(2);
        }

        if (Score >= 50)
        {
            medal(3);
        }

        if (GameOver)
        {
            if (PlayerPrefs.GetInt("HS") < Score)
            {
                PlayerPrefs.SetInt("HS", Score);
            }

            int hs = PlayerPrefs.GetInt("HS");
            HighScore.text = "High Score\n" + hs.ToString();
            ScoreFinal.text = "Score\n" + Score.ToString();
            InGamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }
    }

    void medal(int index)
    {
        Medal[0].SetActive(false);
        Medal[index].SetActive(true);
    }

    public void ScorePlusPlus()
    {
        anim.SetTrigger("Score");
        Score++;
        sfx.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
