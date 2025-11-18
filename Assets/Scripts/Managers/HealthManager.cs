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
    public void UpdateHealth()
    {
        for (int i = 0; i < healthBar.Length; i++)
        {
            if(i < Mathf.CeilToInt((float)player.health))
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
