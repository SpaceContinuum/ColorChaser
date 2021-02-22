using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public static SpawnerScript Instance { get; private set; }
    enum Colors { Red, Green, Black};

    [SerializeField] private float MinXDistance;
    [SerializeField] private float MaxXDistance;
    [SerializeField] private float MinYDistance;
    [SerializeField] private float MaxYDistance;
    [SerializeField] private float MinPlatformL;
    [SerializeField] private float MaxPlatformL;
    [SerializeField] private float spawnChanceRed;
    [SerializeField] private float spawnChanceBlack;
    [SerializeField] private float spawnChanceGreen;
    [SerializeField] private GameObject Platform;
    private int PlatformCounter = 0;

    private Vector3 lastPlatformPos = new Vector3(0, 0, 0);
    private float LastPlatformLength = 0;

    private Coroutine myCoroutine;

    private Dictionary<Colors,Material> Mats = new Dictionary<Colors, Material>();

    //public GameObject[] createdPlatform;
    private List<GameObject> createdPlatform;
    void Awake()
    {
        if (Instance != null)
            throw new System.Exception("More than one singleton exists in the scene!");

        Instance = this;
        
        Mats.Add(Colors.Red,   Resources.Load("RedPlatform")   as Material);
        Mats.Add(Colors.Green, Resources.Load("GreenPlatform") as Material);
        Mats.Add(Colors.Black, Resources.Load("BlackPlatform") as Material);
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
        //startSpawning();

        var curPlatform = Instantiate(Platform, new Vector3(0, 0, 0), Quaternion.identity);
        Platform myPlat = curPlatform.GetComponent<Platform>();
        float Length = Random.Range(MinPlatformL, MaxPlatformL);

        Material Color = GetMats();

        float xDistance = Random.Range(MinXDistance, MaxXDistance);
        float yDistance = Random.Range(MinYDistance, MaxYDistance);
        float x = lastPlatformPos.x + LastPlatformLength + xDistance;
        float y = lastPlatformPos.y + yDistance;
        Vector3 pos = new Vector3(x, y, 0);
        // myPlat.pos = newPos;

        myPlat.SetUp(pos, Length, Color, PlatformCounter);

        lastPlatformPos = pos;
        LastPlatformLength = Length;
        PlatformCounter++;

        if(!GameManager.Instance.msgAddPlatform(curPlatform)) {
            Debug.Log("platform doesn't create");
        }
        
        //send massage to game manager
        yield return new WaitForSeconds(1);
        myCoroutine = null;
    }

    // void startSpawning()
    // {
    //     var curPlatform = Instantiate(Platform, new Vector3(0, 0, 0), Quaternion.identity);
    //     Platform myPlat = curPlatform.GetComponent<Platform>();
    //     float Length = Random.Range(MinPlatformL, MaxPlatformL);

    //     Material Color = GetMats();

    //     float xDistance = Random.Range(MinXDistance, MaxXDistance);
    //     float yDistance = Random.Range(MinYDistance, MaxYDistance);
    //     float x = lastPlatformPos.x + LastPlatformLength + xDistance;
    //     float y = lastPlatformPos.y + yDistance;
    //     Vector3 pos = new Vector3(x, y, 0);
    //     // myPlat.pos = newPos;

        
    //     myPlat.SetUp(pos, Length, Color, PlatformCounter);

    //     lastPlatformPos = pos;
    //     LastPlatformLength = Length;
    //     PlatformCounter++;

    //     // if(!GameManager.Instance.msgAddPlatform(curPlatform)) {
    //     //     Debug.Log("platform doesn't create");
    //     // }

        
    // }

    void StopSpawning()
    {

    }

    private Material GetMats() {
        Material curMat;
        float rnd = Random.value;

        //change
        while(rnd == 0) {
            rnd = Random.value;
        }
        //smallest chance number
        if(rnd <= spawnChanceBlack) {
            curMat = Mats[Colors.Black];
        }
        //highest chance number
        else if(rnd > spawnChanceGreen) {
            curMat = Mats[Colors.Green];
        }
        else {
            curMat = Mats[Colors.Red];
        }

        return curMat;
    }
}
