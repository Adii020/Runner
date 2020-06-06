using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 

public class GameControlScript : MonoBehaviour {
	
	public float objectSpeed = 0;
	
	
	// Czy gra nadal się toczy?
	bool isRunning = true;
	int playerScore = 0;
	

	//Sound
	public AudioClip SoundToPlay;
	private float Volume = 1;
	AudioSource audio;

	public Text TextScore;

	//Menu
	public GameObject Menu;
	private GameObject Playbutton;
	private GameObject Resetbutton;
	private GameObject Quitbutton;


	//Progres bar
	public Image collectBar;

	// zmienna wypełniająca pasek gdy gracz jest na wyznaczonym torze
	public float timeAmt = 100f;
	float time;


	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		TextScore = GameObject.Find("GUI/ScorePanel/Text").GetComponent<Text>();
		Menu = GameObject.Find("GUI/Menu");	
		Playbutton = GameObject.Find("GUI/Menu/Play");
		Quitbutton = GameObject.Find("GUI/Menu/Quit");
		Resetbutton = GameObject.Find("GUI/Menu/Reset");
		Playbutton.SetActive(true);
		Quitbutton.SetActive(true);
		Resetbutton.SetActive(false);
		Playbutton.GetComponent<Button>().onClick.AddListener(PlayGame);
		Resetbutton.GetComponent<Button>().onClick.AddListener(ResetGame);
		Quitbutton.GetComponent<Button>().onClick.AddListener(QuitGame);

		collectBar = GameObject.Find("GUI/BarPanel/PointBarCol1/PointBarCol2").GetComponent<Image>();
		collectBar.fillAmount = 0.5f;


	}

	// Update is called once per frame
	void Update () {
		checkGameover();

	}


	// sprawdzaie czy gracz przegrał przez zapełnienie paska balansu
	void checkGameover()
    {
		if (collectBar.fillAmount == 0f || collectBar.fillAmount == 1f)
		{
			PlayerDied();
		}
	}

	void PlayGame()
	{
		//Application.LoadLevel("Level1");
		isRunning = true;
		Time.timeScale = 1.0f;
		objectSpeed = -0.6f;
		Menu.SetActive(false);
	}

	void ResetGame()
	{
		SceneManager.LoadScene("Level1");
	}

	void QuitGame()
    {
		Application.Quit();
		Debug.Log("Game is exiting");
	}

    public void TimeAdd()
    {
		time = Time.deltaTime;
		collectBar.fillAmount -= time / timeAmt;

	}

	public void TimeSub()
	{
		time = Time.deltaTime;
		collectBar.fillAmount += time / timeAmt;
		
	}

	//Dodawanie puntków wywoływane przez PlayerControler gdy gracz dotkie żółtego punktu
	public void AddScore()
	{
		playerScore++;
		//Debug.Log(playerScore);
		TextScore.text = "Punkty: " + playerScore.ToString();
	}


	public void PlayerDied()
	{
		Playbutton.SetActive(false);
		Quitbutton.SetActive(true);
		Resetbutton.SetActive(true);
		isRunning = false;
		Time.timeScale = 0f;
		objectSpeed = 0f;
		Menu.SetActive(true);
	}

	// Dźwięk zebrania przedmiotu
	public void PlayCollectCoinSound()
	{
		GetComponent<AudioSource>().PlayOneShot(SoundToPlay, Volume);
	}

	
}
