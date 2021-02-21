using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public ScoreBase score;

    void Awake() {
         if (Instance != null)
            throw new System.Exception("More than one singleton exists in the scene!");

        Instance = this;

        score = new ScoreBase();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call when player start
    void setPlayerName(string curName) {
        score.Name = curName;
    }

    //call when player died
    void setPlayerScore(int curScore) {
        score.Score = curScore;
        score.Time = System.DateTime.Now;
    }
}
