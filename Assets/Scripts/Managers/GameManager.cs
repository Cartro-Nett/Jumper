using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBackGround;
    [SerializeField] AudioClip audioBackGround;
    [SerializeField] AudioSource audioSourceEffects;
    [SerializeField] AudioClip[] audioEffects;

    [SerializeField] GameObject[] textScreens;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("backGroundMusic", 0.1f, 144f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backGroundMusic()
    {
        audioSourceBackGround.PlayOneShot(audioBackGround, 0.4f);
    }
    public void gameOver()
    {
        audioSourceEffects.PlayOneShot(audioEffects[0]);
        textScreens[0].SetActive(true);
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
}
