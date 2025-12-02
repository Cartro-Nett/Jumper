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


    [SerializeField] AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
        audioManager =  GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        InvokeRepeating("backGroundMusic", 0.1f, 130f);
        
        updateHighScore();
    }
    public void backGroundMusic()
    {
        if(audioManager != null && audioManager.isItPlaying == true)
        {
            Debug.Log("Off");
          audioSourceBackGround.Stop();
        }
        else
        {
            Debug.Log("On");
            audioSourceBackGround.PlayOneShot(audioBackGround, 0.1f);
        }
        
    }
    public void gameOver()
    {
        audioSourceEffects.PlayOneShot(audioEffects[0]);
        textScreens[0].SetActive(true);
        
    }
    public void pause()
    {
        if (textScreens[1]  != null)
        {
            textScreens[1].SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
        } 
    }
    public void resume()
    {
        textScreens[1].SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void exitLevel()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
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
    public void completedLevel()
    {
        if(playerScore > highScore)
        {
            audioSourceEffects.PlayOneShot(audioEffects[1]);
            textScreens[2].SetActive(true);
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();
        }
        else
        {
            textScreens[3].SetActive(true);
            audioSourceEffects.PlayOneShot(audioEffects[2]);
        }
        Invoke("EndOfLevel", 7f);
        
    }
    void EndOfLevel()
    {
        SceneManager.LoadSceneAsync(0);
        Cursor.visible = true;
    }
    public void controlScreen()
    {
        textScreens[4].SetActive(false);
        textScreens[5].SetActive(true);
    }
    public void exitControlScreen()
    {
        textScreens[4].SetActive(true);
        textScreens[5].SetActive(false);
    }
}
