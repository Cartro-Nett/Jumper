using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image[] healthBar;
    Player_Health player;
    private void Start()
    {
        player = FindAnyObjectByType<Player_Health>();
    }
    // This is the display to health bar using the players health to
    // determine if its red or black
    public void UpdateHealth()
    {
        for (int i = 0; i < healthBar.Length; i++)
        {
            if(i < player.health)
            {
                healthBar[i].color = Color.red;
            }
            else
            {
                healthBar[i].color = Color.black;
            }
        }
    }
}
