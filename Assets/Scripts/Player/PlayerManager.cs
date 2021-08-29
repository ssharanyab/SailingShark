using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numberOfcoins = 0;

    public Text coinsText;
    void Start()
    {
        GameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfcoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        coinsText.text = "Points:  " + numberOfcoins;
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
