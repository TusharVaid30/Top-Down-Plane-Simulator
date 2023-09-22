using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator transitionClouds;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text highestTimeText;
    [SerializeField] private TMP_Text highestCoinsText;

    private void Start()
    {
        Time.timeScale = 1f;
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetFloat("HIGHSCORE");
        highestTimeText.text = "MOST TIME SURVIVED: " + PlayerPrefs.GetFloat("TIME");
        highestCoinsText.text = "MOST COINS COLLECTED: " + PlayerPrefs.GetFloat("COINS");
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Play()
    {
        transitionClouds.Play("HideClouds", -1, 0f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
