using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    
    public void StartGame()
    {
        Player.PlayerStats._currentHealth = Player.PlayerStats.MaxHP;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quited the game");
        Application.Quit();
    }


}
