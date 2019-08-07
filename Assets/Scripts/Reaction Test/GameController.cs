using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class GameController : MonoBehaviour {

	private Camera bg;

	public float ThisRunTime = 0;
	public float WaitingTime = 0;
	public float RunWaitingTime;
	public bool next;
	public bool timerOn;
	public bool start;

	public Text AvgTimer;
    public Text ThisTimer;
	public GameObject Button;
	public Text Messege;
    public PauseMenuButton pmb;

	private Color _red = new Color (214f / 255f, 40f / 255f, 31f / 255f);
	private Color _green = new Color (63 / 255f, 210 / 255f, 36 / 255f);
	private Color _blue = new Color (107f / 255f, 192f / 255f, 242f / 255f);

	private string _greeting = "Click to start :)";
	private string _wait = "Wait for green...";
	private string _click = "Click now!";
	private string _tosoon = "To soon :(";
    private string _nextTry = "Click to next";

	void Start () 
	{
		start = true;
		bg = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		bg.backgroundColor = _blue;
		Messege.text = _greeting;
		next = false;
		timerOn = false;
	}

	void OnMouseDown () 
	{
		if (!timerOn && bg.backgroundColor == _red && !start && !pmb.menuOpen) {
			//GetComponent <TimerContrl> ().MissClick ();
			Messege.text = _tosoon;
			Reset ();
		} else if (timerOn && bg.backgroundColor == _green && !start && !pmb.menuOpen) {
			GetComponent<TimerContrl> ().GetTimers ();
			Messege.text = _nextTry;
			Reset ();
		} else if (!timerOn && bg.backgroundColor == _blue && !start && !pmb.menuOpen) {
            bg.backgroundColor = _red;
			Messege.text = _wait;
			next = true;
			RunWaitingTime = 0;
			AvgTimer.text = null;
            ThisTimer.text = null;
		} else if (start && !pmb.menuOpen) {
			start = false;
			next = true;
            bg.backgroundColor = _red;
			Messege.text = _wait;
		}
	}

	void Update ()
	{
		if (next && !pmb.menuOpen) 
			NewTry ();
		if (WaitingTime > 0 && !pmb.menuOpen)
			Waiting ();
		if (timerOn && !pmb.menuOpen) {
			ThisRunTime += Time.deltaTime;
		}		
	}

	void Reset ()
	{
        bg.backgroundColor =  _blue;
		timerOn = false;
		ThisRunTime = 0;
		WaitingTime = 0;
	}

	void Waiting ()
	{
		if (RunWaitingTime <= WaitingTime) {
			RunWaitingTime += Time.deltaTime;
		} else {
			WaitingTime = 0;
			timerOn = true;
			Messege.text = _click;
            bg.backgroundColor = _green;
		}
	}

	void NewTry()
	{
		WaitingTime = Random.Range (0.5f, 5f);
		next = false;
	}		
}