using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = SceneManagerScript.Instance.curGameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain() {
        SceneManagerScript.Instance.LoadGame();
    }

    public void MainMenu() {
        //debug Only
        SceneManagerScript.Instance.playerName = "";

        //after publish
        PlayerPrefs.SetString("playerName","");

        
        SceneManager.LoadScene("Opening");
    }
}
