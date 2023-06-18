using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int score = 1;
    public int hiScore;
    public TextMeshProUGUI scoreText;

    public static GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager object doesn't destroy when changing scene
        /*if(gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if(gameManager != this)
        {
            Destroy(gameObject);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Slicecore: "+score.ToString();

        if(score > PlayerPrefs.GetInt("HiScore"))
        {
            hiScore = score;
            PlayerPrefs.SetInt("HiScore", hiScore);
        }

    }

}
