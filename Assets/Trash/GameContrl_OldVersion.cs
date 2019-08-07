
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContrl_OldVersion : MonoBehaviour
{
    [SerializeField]
    private WordsList _wordsList;
    private GameObject _timer;
    [SerializeField]
    private Text _directionText;

    [SerializeField]
    private Vector2 mousePosDown, mousePosUp;
    private Image _playground;
    private string direction;
    private bool _isStarted;
    [SerializeField]
    private bool _upScore;
    private int screenWidth, screenHeight;
    
    public int Score;
    public int Miss;

    private void Awake()
    {
        _timer = GameObject.FindGameObjectWithTag("Timer");
    }

    void Start ()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        _playground = GetComponent<Image>();
        Score = 0;
        Miss = 0;
        _isStarted = true;
	}

    private void OnMouseDown()
    {
        mousePosDown = new Vector2
            (
                Input.mousePosition.x / screenWidth, 
                Input.mousePosition.y / screenHeight
            );
    }

    private void OnMouseUp()
    {
        mousePosUp = new Vector2
            (
                Input.mousePosition.x / screenWidth,
                Input.mousePosition.y / screenHeight
            );
        _upScore = AccuracyCheck(mousePosDown, mousePosUp);
        if (_upScore)
            Score += 1;
        else
            Miss += 1;
        _isStarted = true;
    }

    
    void Update ()
    {
        if (_isStarted)
            NextDirection();
	}

    void NextDirection()
    {
        direction = _wordsList.ChouseDirection();
        _directionText.text = direction;
        _isStarted = false;
        //Debug.Log(direction);
    }

    private bool AccuracyCheck(Vector2 down, Vector2 up)
    {
        float differenceX = up.x - down.x;
        float differenceY = up.y - down.y;
        bool dif = Mathf.Abs(differenceX) > Mathf.Abs(differenceY);
        switch (direction)
        {
            case "up":
                if (down.x < up.x)
                    return true;
                break;
            case "down":
                if (down.x > up.x)
                    return true;
                break;
            case "left":
                if (down.y > up.y)
                    return true;
                break;
            case "right":
                if (down.y < up.y)
                    return true;
                break;
            case "not up":
                if (dif || down.x > up.x)
                    return true;
                break;
            case "not down":
                if (dif || down.x < up.x)
                    return true;
                break;
            case "not left":
                if (!dif || down.y < up.y)
                    return true;
                break;
            case "not right":
                if (!dif || down.y > up.y)
                    return true;
                break;
            default:
                return false;
        }
        return false;
    }

}
