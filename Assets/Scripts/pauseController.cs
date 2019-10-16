using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("Its " + pausePanel.activeInHierarchy + " Bro...");
            if (!pausePanel.activeInHierarchy)
            {
                Debug.Log("Paused");
                PauseGame();
            }
            else {
                Debug.Log("Unpaused");
                ContinueGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
