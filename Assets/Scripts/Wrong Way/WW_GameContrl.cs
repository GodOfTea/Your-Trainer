using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WW_GameContrl : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField]
    private WordsList _wordsList;
    private Text Timer;
    private Text score;
    [SerializeField]
    private Text _directionText;

    public PauseMenuButton pmb;
    public Common_timer timer;

    private string direction;
    private bool _isStarted;

    public int bestScore;
    public Text endScoreText;
    public Text endBestScoreText;
    public bool endGame;
    public int Score;

    public GameObject[] endMenu = new GameObject[3];
    public GameObject[] startMenu = new GameObject[3];

    private void Awake()
    {
        Timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        for (int i = 0; i < endMenu.Length; i++)
        {
            endMenu[i].SetActive(false);
            startMenu[i].SetActive(true);
        }
    }

    void Start ()
    {
        if (!PlayerPrefs.HasKey("WWBestScore"))
            PlayerPrefs.SetInt("WWBestScore", -999999);
        else
            bestScore = PlayerPrefs.GetInt("WWBestScore");
        Score = 0;
        //Miss = 0;
        _isStarted = true;
        endGame = false;
        score.text = "Score: " + Score;
	}

    void Update ()
    {
        if (!pmb.menuOpen && !endGame)
        {
            endGame = timer.CountTime();
        }
        if (_isStarted && !pmb.menuOpen && !endGame)
            NextDirection();
        else if (endGame)
        {
            EndGame();
        }
	}

    public void EndGame ()
    {
        if (Score > bestScore)
        {
            bestScore = Score;
            PlayerPrefs.SetInt("WWBestScore", bestScore);
            //GameObject.FindGameObjectWithTag("RecordsMenu").GetComponent<RecordsController>().UpdateRecords();
        }
        //endGame = true;
        endScoreText.text = score.text;
        endBestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("WWBestScore").ToString();
        for (int i = 0; i < 3; i++)     //3 = end and start menu lenght
        {
            endMenu[i].SetActive(true);
            startMenu[i].SetActive(false);
        }
    }

    void NextDirection()
    {
        direction = _wordsList.ChouseDirection();
        _directionText.text = direction;
        _isStarted = false;
        //Debug.Log(direction);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        bool dif = (Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y));

        if (dif && !pmb.menuOpen && !endGame) // 
        {
            if (eventData.delta.x > 0 && (direction == "right" || direction == "not left" || direction == "not down" || direction == "not up"))
                Score += 1;
            else if (eventData.delta.x < 0 && (direction == "left" || direction == "not right" || direction == "not down" || direction == "not up"))
                Score += 1;
        }
        else if (!dif && !pmb.menuOpen && !endGame)
        {
            if (eventData.delta.y > 0 && (direction == "up" || direction == "not left" || direction == "not down" || direction == "not right"))
                Score += 1;
            else if (eventData.delta.y < 0 && (direction == "down" || direction == "not right" || direction == "not left" || direction == "not up"))
                Score += 1;
        }
        score.text = "Score: " + Score;
        _isStarted= true;
    }

    public void OnDrag(PointerEventData eventData)
    {   }
}
