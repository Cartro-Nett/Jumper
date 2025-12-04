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
    // The backgroundMusic will still needs improving.
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
    // When game over happens it shows this screen
    public void gameOver()
    {
        audioSourceEffects.PlayOneShot(audioEffects[0]);
        textScreens[0].SetActive(true);
        Cursor.visible = true;
    }
    // When the player pauses it will show this screen.
    public void pause()
    {
        if (textScreens[1]  != null)
        {
            textScreens[1].SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
        } 
    }
    // When the player is in the pause screen, this will get player back to game.
    public void resume()
    {
        textScreens[1].SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    // In pause screen, the player can restart the level.
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    // In pause screen, if the player wants to exit the level.
    public void exitLevel()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
    //In the title page of the game the player can quit game.
    public void quitGame()
    {
        Application.Quit();
    }
    // Gets the player into the tutorial.
    public void tutorial()
    {
        SceneManager.LoadSceneAsync(3);
    }
    // Gets the player to the first scene.
    public void firstLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }
    // Gets the player to the second Scene. - might not be fully done.
    public void secondLevel()
    {
        SceneManager.LoadSceneAsync(2);
    }
    // Will display the players score for them to see.
    public void addScore(int scoreAdd)
    {
        playerScore += scoreAdd;
        scoreText.text = playerScore.ToString();
        
    }
    // Will save the high score of the game.
    public void updateHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"HighScore: {highScore}";
    }
    // When the player completes the level will choose from two screen options,
    // one a new high score achieved and the other being if player does not achieve the high score. 
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
    // Will load the title page of the game.
    void EndOfLevel()
    {
        SceneManager.LoadSceneAsync(0);
        Cursor.visible = true;
    }
    //The options for the controls of the game, will de-active the other ui when active
    public void controlScreen()
    {
        textScreens[4].SetActive(false);
        textScreens[5].SetActive(true);
    }
    // This will ecit the control screen and restore the pervious ui.
    public void exitControlScreen()
    {
        textScreens[4].SetActive(true);
        textScreens[5].SetActive(false);
    }
}
