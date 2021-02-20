using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake() {

        //כדי שנוכל לפנות אל ה
        //GameManager
        //מהקוד של הפלטפורמה
        if (Instance != null)
            throw new Exception("More than one singleton exists in the scene!");

        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool msgAddPlatform(GameObject platform) {
        //do other stuff
        return true;
    }
    public bool msgRemovePlatform(GameObject platform) {
        //do other stuff
        return true;
    }
}
