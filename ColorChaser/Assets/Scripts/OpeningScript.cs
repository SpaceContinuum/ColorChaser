using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScript : MonoBehaviour
{

    [SerializeField] private InputField playerNameField;

    [SerializeField] private Text[] topScoresNames;
    [SerializeField] private Text[] topScoresScores;
    [SerializeField] private Text[] topScoresDates;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManagerScript.Instance.topScoresJsonTemp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGameClick()
    {

        //debug Only
        SceneManagerScript.Instance.playerName = playerNameField.text;

        //after publish
        PlayerPrefs.SetString("playerName", playerNameField.text);


        SceneManagerScript.Instance.LoadGame();
    }

    public void ShowTopScores()
    {

        for (int j = 0; j < 3; j++)
        {
            topScoresNames[j].text = "";
            topScoresScores[j].text = "";
            topScoresDates[j].text = "";
        }

        //for Debug only
        string topScoresJson = SceneManagerScript.Instance.topScoresJsonTemp;

        //string topScoresJson = PlayerPrefs.GetString("TopScores");

        if (topScoresJson != "")
        {
            List<ScoreBase> TopScores = JsonUtility.FromJson<List<ScoreBase>>(topScoresJson).OrderByDescending(s => s.Score).ToList();

            int i = 0;
            foreach (ScoreBase score in TopScores)
            {
                topScoresNames[i].text = score.Name;
                topScoresScores[i].text = score.Score.ToString();
                topScoresDates[i].text = score.Time.ToString("d");
                i++;
            }



        }

    }
}
