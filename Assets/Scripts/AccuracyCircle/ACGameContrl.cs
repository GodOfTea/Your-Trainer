using UnityEngine;
using UnityEngine.UI;

public class ACGameContrl : MonoBehaviour 
{
    public CircleSpawner cs;
    public Common_timer timer;
    public PauseMenuButton pmb;
    //GameObject rc;

    public int score;
    public int bestScore;
    Text scoreText;
    public Text endScoreText;
    public Text endBestScoreText;
    string strScore = "Score: ";
    public bool endGame;

    public GameObject[] endMenu = new GameObject[3];
    public GameObject[] startMenu = new GameObject[3];

    void Awake()
    {
        //rc = GameObject.FindGameObjectWithTag("RecordsMenu");
        for (int i = 0; i < endMenu.Length; i++)
        {
            endMenu[i].SetActive(false);
            startMenu[i].SetActive(true);
        }
    }
    void Start () 
	{
        if (!PlayerPrefs.HasKey("ACBestScore"))
            PlayerPrefs.SetInt("ACBestScore", -999999);
        else
            bestScore = PlayerPrefs.GetInt("ACBestScore");
        score = 0;
        endGame = false;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        UpdateScore(score);
    }

    void Update()
    {
        if (cs.startGame && !endGame && !pmb.menuOpen)
        {
            endGame = timer.CountTime();
        }
        if (endGame == true)
        {
            EndGame();
        }
    }
	
    public void UpdateScore (int points)
    {
        score += points;
        scoreText.text = strScore + score.ToString();
    }

    public void EndGame ()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("ACBestScore", bestScore);
            //GameObject.FindGameObjectWithTag("RecordsMenu").GetComponent<RecordsController>().UpdateRecords();
        }
        //endGame = true;
        endScoreText.text = scoreText.text;
        endBestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("ACBestScore").ToString();
        for (int i = 0; i < 3; i++)     //3 = end and start menu lenght
        {
            endMenu[i].SetActive(true);
            startMenu[i].SetActive(false);
        }
    }
}
