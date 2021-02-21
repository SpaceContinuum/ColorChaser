using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<Platform> platforms;
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

    public bool msgAddPlatform(GameObject pltfrm) {
        Platform platform = pltfrm.GetComponent<Platform>();

        if (!PlatformExists(platform.getID()))
        {
            platforms.Add(platform);
            return true;
        }
        return false;
    }
    public bool msgRemovePlatform(int id)
    {
        for (int i = 0; i<= platforms.Count; i++)
        {
            if(platforms[i].getID() == id)
            {
                platforms.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    private bool PlatformExists(int id)
    {
        foreach (Platform pltfrm in platforms)
        {
            if(pltfrm.getID() == id)
            {
                return true;
            }
        }
        return false;
    }
}
