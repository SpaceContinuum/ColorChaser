using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<Platform> platforms;

    private float jumpMult=2f;
    private bool isColor=true;
    [SerializeField] private float blackOutTime=3f;

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

    public float getJumpMult()
    {
        return jumpMult;
    }

    public bool msgPlatformHit(float jmpMlt)
    {
        if (jmpMlt != 0)
        {
            jumpMult = jmpMlt;
            return true;
        }
        return false;
    }

    public bool msgBlackPlatformHit()
    {
        if (platforms.Count > 0 && isColor)
        {
            TurnPlatforms();
            Invoke("TurnPlatforms", blackOutTime);
            return true;
        }
        return false;
    }

    public bool TurnPlatforms()
    {
        if (platforms.Count > 0)
        {
            foreach (Platform pltfrm in platforms)
            {
                pltfrm.TurnColor(isColor);
            }
            isColor = !isColor;
            return true;
        }
            return false;
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
        if (platforms.Count > 0)
        {
            foreach (Platform pltfrm in platforms)
            {
                if (pltfrm.getID() == id)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
