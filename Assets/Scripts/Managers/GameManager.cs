using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBackGround;
    [SerializeField] AudioClip audioBackGround;
    [SerializeField] AudioSource audioSourceEffects;
    [SerializeField] AudioClip[] audioEffects;

    [SerializeField] GameObject[] textScreens;


    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public static int highScore;
    [SerializeField] TextMeshProUGUI highScoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("backGroundMusic", 0.1f, 144f);
        
        updateHighScore();
    }
    public void backGroundMusic()
    {
        audioSourceBackGround.PlayOneShot(audioBackGround, 0.1f);
    }
    public void gameOver()
    {
        audioSourceEffects.PlayOneShot(audioEffects[0]);
        textScreens[0].SetActive(true);
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();

        }
    }
    public void pause()
    {
        if (textScreens[1]  != null)
        {
            textScreens[1].SetActive(true);
        } 
    }
    public void resume()
    {
        textScreens[1].SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void firstLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void addScore(int scoreAdd)
    {
        playerScore += scoreAdd;
        scoreText.text = playerScore.ToString();
        
    }
    public void updateHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"HighScore: {highScore}";
    }
}
