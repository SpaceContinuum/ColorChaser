using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public static SpawnerScript Instance { get; private set; }

    public float MinXDistance;
    public float MaxXDistance;
    public float MinYDistance;
    public float MaxYDistance;
    public float MinPlatformL;
    public float MaxPlatformL;
    public float spawnChanceRed;
    public float spawnChanceBlack;
    public float spawnChanceGreen;
    public int PlatformCounter;
    public GameObject Platform;

    private Vector3 lastPlatformPos = new Vector3(0, 0, 0);
    private float LastPlatformLength = 0;

    private Coroutine myCoroutine;

    private Dictionary<string,Material> Mats = new Dictionary<string, Material>();

    //temp
    //private string[] colors = new string[3] { "red", "green", "black" };

    //public GameObject[] createdPlatform;
    private List<GameObject> createdPlatform;
    void Awake()
    {
        if (Instance != null)
            throw new System.Exception("More than one singleton exists in the scene!");

        Instance = this;
        
        Mats.Add("red", Resources.Load("RedPlatform") as Material);
        Mats.Add("green", Resources.Load("GreenPlatform") as Material);
        Mats.Add("black", Resources.Load("BlackPlatform") as Material);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(myCoroutine == null)
        {
            myCoroutine = StartCoroutine(spawn());
        }
        
    }

    IEnumerator spawn() {
        
        startSpawning();

        //send massage to game manager
        yield return new WaitForSeconds(1);
        myCoroutine = null;
    }

    void startSpawning()
    {
        var curPlatform = Instantiate(Platform, new Vector3(0, 0, 0), Quaternion.identity);
        Platform myPlat = curPlatform.GetComponent<Platform>();
        myPlat.Length = Random.Range(MinPlatformL, MaxPlatformL);
        //int colorIndex = Random.Range(0, 3);
        //myPlat.Color = colors[colorIndex];

        myPlat.Color = GetMats();

        float xDistance = Random.Range(MinXDistance, MaxXDistance);
        float yDistance = Random.Range(MinYDistance, MaxYDistance);
        float x = lastPlatformPos.x + LastPlatformLength + xDistance;
        float y = lastPlatformPos.y + yDistance;
        Vector3 newPos = new Vector3(x, y, 0);
        myPlat.pos = newPos;

        myPlat.SetUp();

        lastPlatformPos = myPlat.pos;
        LastPlatformLength = myPlat.Length;
    }

    void StopSpawning()
    {

    }

    private Material GetMats() {
        Material curMat;
        float rnd = Random.value;

        while(rnd == 0) {
            rnd = Random.value;
        }
        //smallest chance number
        if(rnd <= spawnChanceBlack) {
            Debug.Log("black");
            curMat = Mats["black"];
        }
        //highest chance number
        else if(rnd > spawnChanceGreen) {
            Debug.Log("green");
            curMat = Mats["green"];
        }
        else {
            Debug.Log("red");
            curMat = Mats["red"];
        }

        Debug.Log(curMat);
        Debug.Log(rnd);

        return curMat;
    }
}
