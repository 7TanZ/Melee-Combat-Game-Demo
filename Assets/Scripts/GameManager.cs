using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Health playerHealth;
    public Health enemyHealth;

    public GameObject winUI;
    public GameObject loseUI;

    public static bool GameEnded = false;

    void Update()
    {
        if (GameEnded) return;

        if (enemyHealth != null && enemyHealth.isDead)
            WinGame();

        if (playerHealth != null && playerHealth.isDead)
            LoseGame();
    }

    void WinGame()
    {
        GameEnded = true;
        Debug.Log("YOU WIN");

        if (winUI != null)
            winUI.SetActive(true);
    }

    void LoseGame()
    {
        GameEnded = true;
        Debug.Log("YOU LOSE");

        if (loseUI != null)
            loseUI.SetActive(true);
    }

    // ⭐ BUTTON FUNCTIONS

    public void RestartGame()
    {
        GameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");

        Application.Quit();

        // Editor safety
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
