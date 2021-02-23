using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private List<Platform> platforms = new List<Platform>();

    private float jumpMult;
    private bool isColor=true;
    private float minPlatformHeight=0f;

    [SerializeField] private float blackOutTime=3f;
    [SerializeField] private float GreenJumpForce = 300f;
    [SerializeField] private float RedJumpForce = 300f;
    [SerializeField] private GameObject player;

    private void Awake()
    {

        if (Instance != null)
            throw new Exception("More than one singleton exists in the scene!");

        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GreenJumpForce = Mathf.Abs(GreenJumpForce);
        RedJumpForce   = Mathf.Abs(RedJumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= 1.2*minPlatformHeight)
        {
            msgGameOver();
        }
    }

    public float getJumpMult()
    {
        return jumpMult;
    }

    public float getGreenJumpForce()
    {
        return GreenJumpForce;
    }

    public float getRedJumpForce()
    {
        return RedJumpForce;
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
                pltfrm.TurnColor(!isColor);
            }
            Debug.Log("colored platform? " + isColor);
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
            if (minPlatformHeight > pltfrm.transform.position.y)
            {
                minPlatformHeight = pltfrm.transform.position.y;
            }

            if(!isColor)
            {
                platform.TurnColor(isColor);
            }
            return true;
        }
        return false;
    }

    public bool msgRemovePlatform(int id)
    {
        for (int i = 0; i<= platforms.Count; i++)
        {
            if (platforms[i].getID() == id)
            {
                platforms.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    public void msgGameOver()
    {
        SceneManagerScript.Instance.GameOver();
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
