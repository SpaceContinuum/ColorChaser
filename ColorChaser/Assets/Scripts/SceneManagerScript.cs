using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{

    public static SceneManagerScript Instance { get; private set; }

    public float curGameScore;
    private ScoreBase score;
    [SerializeField] private List<ScoreBase> TopScores = new List<ScoreBase>();
    private int TopScoresCount = 3;
    public string playerName;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            //throw new System.Exception("More than one singleton exists in the scene!");
        }
        else
        {
            Instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        //active before publish
        string playerName = PlayerPrefs.GetString("playerName");

        score = new ScoreBase();
        score.Name = playerName;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("EndlessRunner");
    }

    void UpdateTopScores()
    {
        if (TopScores.Count < TopScoresCount)
        {
            TopScores.Add(score);
        }
        else
        {
            var LowestScore = TopScores.Min(s => s.Score);
            if (score.Score > LowestScore)
            {
                TopScores.Add(score);
                var scoreToRemove = TopScores.First(s => s.Score == LowestScore);
                TopScores.Remove(scoreToRemove);
            }
        }

        string ScoresString = "";
        foreach (var ts in TopScores)
        {
            ScoresString += JsonUtility.ToJson(ts) + ";";
        }

        ScoresString = ScoresString.Substring(0, ScoresString.Length - 1);

        PlayerPrefs.SetString("TopScores", ScoresString);

        SceneManager.LoadScene("GameOver");

    }

    public void GameOver()
    {
        curGameScore =  Mathf.Floor(Time.timeSinceLevelLoad);
        score.Score = curGameScore;
        UpdateTopScores();
    }
}
