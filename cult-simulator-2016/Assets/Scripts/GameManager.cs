using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager gm;

	public GameObject uiCanvas;
	public Text scoreDisplay;
	public Text livesDisplay;

	public GameObject gameOverCanvas;
	public Text gameOverScore;

	[Tooltip("Main source for background music.")]
	public AudioSource musicAudioSource;

	[Tooltip("Multiply the pitch of background music by given value.\nValues smaller than 1 lead to slower speeds.\nNegative time causes the music to play from end to start.\nFind your demonic messages easily.")]
	public float musicSpeedUp;
	public float gameOverPitch;
	public float gameStartPitch;

	public float[] speadUpTimes;

	public int score = 0;
	public int lives = 3;

	[HideInInspector]
	public float currentTime = 0.0f;
	public bool gameIsOver = false;

	public PlayerFollowerScript pfs;
	// Use this for initialization
	void Start () {
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();
		gameIsOver = false;
		if (uiCanvas)
			uiCanvas.SetActive (true);
		if (gameOverCanvas)
			gameOverCanvas.SetActive (false);
		if (musicAudioSource)
			musicAudioSource.pitch = gameStartPitch;
		scoreDisplay.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (pfs.testPosition (Position.front, Position.front, Position.none));
	}

	void GameOver () {
		gameIsOver = true;
		if (uiCanvas)
			uiCanvas.SetActive (false);
		if (gameOverCanvas)
			gameOverCanvas.SetActive (true);
		if (musicAudioSource)
			musicAudioSource.pitch = gameOverPitch;
	}

	public float PoseCheck (Position left, Position right, Position head) {
		if (pfs.testPosition (left, right, head)) {
			score += 1;
			scoreDisplay.text = score.ToString();
		} else {
			lives = lives - 1;
			if (lives == 0) {
				GameOver();
				return 0.0f;
			}
		}
		float speedUp = 1.00f + (score / 10.0f) * musicSpeedUp;
		if (musicAudioSource)
			musicAudioSource.pitch = speedUp;
		return speedUp;
	}
}
