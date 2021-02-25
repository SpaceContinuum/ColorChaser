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
            //topScoresDates[j].text = "";
        }

        // //for Debug only
        // string topScoresJson = SceneManagerScript.Instance.topScoresJsonTemp;

        string topScoresJson = PlayerPrefs.GetString("TopScores");
        Debug.Log(topScoresJson);

        if (topScoresJson != "")
        {
            string[] scoresArr = topScoresJson.Split(';');
            
            List<ScoreBase> topScores = new List<ScoreBase>(); 

            for (int i = 0; i < scoresArr.Length; i++)
            {
                ScoreBase curScore = JsonUtility.FromJson<ScoreBase>(scoresArr[i]);

                topScores.Add(curScore);
            }

            topScores = topScores.OrderByDescending(s => s.Score).ToList();

            foreach (var item in topScores.Select((value, i) => new { i, value }))
            {
                topScoresNames[item.i].text = item.value.Name;
                topScoresScores[item.i].text = item.value.Score.ToString();
            }
            //ScoreBase[] TopScores = JsonUtility.FromJson<ScoreBase[]>(topScoresJson);
            //.OrderByDescending(s => s.Score).ToList()
            // int i = 0;
            // foreach (ScoreBase score in TopScores)
            // {
            //     topScoresNames[i].text = score.Name;
            //     topScoresScores[i].text = score.Score.ToString();
            //     //topScoresDates[i].text = score.Time.ToString("d");
            //     i++;
            // }



        }

    }
}
