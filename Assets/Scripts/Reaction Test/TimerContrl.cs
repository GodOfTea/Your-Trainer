using UnityEngine;
using UnityEngine.UI;

public class TimerContrl : MonoBehaviour 
{
	public GameObject canvas;
	public GameObject timer_pref;
	public GameObject avgTimer;
    public GameObject thisTimer;

    private int _total;
	//private int timerCount;
	private int YtimerPos;
	private float _avgTime;
	private float _thisRunTime;
	private float sumTime;
	private float bestScore;

	//private GameObject[] _timers = new GameObject[5];

	void Start () 
	{
		sumTime = 0;
		_total = 0;
		_avgTime = 0;
		if (!PlayerPrefs.HasKey("RTBestScore"))
		{
			PlayerPrefs.SetFloat("RTBestScore", 99999);
		}
		else
		{
			bestScore = PlayerPrefs.GetFloat("RTBestScore");
		}
		//Reset ();
	}

	public void GetTimers() //если хочешь убрать таймеры слева, то комменть
	{	
		_total++;
        ThisTimer();
        AverageTimer();

        /*
		if (timerCount < 5) {
        	if (_timers [timerCount] != null)
        		Destroy (_timers [timerCount]);
        _timers[timerCount] = Instantiate (timer_pref, timer_pref.transform.position = new Vector3 (150, YtimerPos, 10), Quaternion.identity) as GameObject;
        _timers[timerCount].transform.SetParent (canvas.transform, false);
        _timers[timerCount].GetComponent<Text> ().text = _thisRunText;

        AverageTimer ();

        YtimerPos -= 100;
        timerCount++;

        } else {
        	Reset (); 
        	Spawn ();
        }
        */
        
    }
    /*
	void Reset ()
	{
		timerCount = 0;
		YtimerPos = 1300;
	}
    */

    void ThisTimer()
    {
        _thisRunTime = GetComponent<GameController>().ThisRunTime;
        thisTimer.GetComponent<Text>().text = _thisRunTime.ToString("0.000");
		if (_thisRunTime < bestScore)
		{
			PlayerPrefs.SetFloat("RTBestScore", _thisRunTime);
			bestScore = _thisRunTime;
			//GameObject.FindGameObjectWithTag("RecordsMenu").GetComponent<RecordsController>().UpdateRecords();
		}
    }

	void AverageTimer ()
	{
		sumTime += _thisRunTime;
		_avgTime = sumTime / _total;
		avgTimer.GetComponent<Text> ().text = "Average time:\n" + _avgTime.ToString("0.000");
	}
}