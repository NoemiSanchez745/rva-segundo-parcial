using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public GameObject startPanel;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Entró a start Game");
        startPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
