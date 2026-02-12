using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startUI;

    void Start()
    {
        GameManager.GameEnded = true;   // Freeze game at start
    }

    public void PlayGame()
    {
        GameManager.GameEnded = false;  // Start gameplay

        if (startUI != null)
            startUI.SetActive(false);
    }
}
    