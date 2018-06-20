using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    
    public void StartGame()
    {
        Player player = new Player();
        player.LoadPlayerData();
        Player.PlayerStats._currentHealth = Player.PlayerStats.MaxHP;
        Player.PlayerStats._currentKi = Player.PlayerStats.MaxKi;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quited the game");
        Application.Quit();
    }


}
