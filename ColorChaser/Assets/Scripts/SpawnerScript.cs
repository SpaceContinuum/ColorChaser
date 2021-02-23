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

    private List<Material> Mats = new List<Material>();
    private int[] jumpCoeff = { -1, 1, 0 };
    private float[] jumpMult = new float[3];

    //public GameObject[] createdPlatform;
    private List<GameObject> createdPlatform;
    void Awake()
    {
        if (Instance != null)
            throw new System.Exception("More than one singleton exists in the scene!");

        Instance = this;
        
        Mats.Add(Resources.Load("RedPlatform")   as Material);
        Mats.Add(Resources.Load("GreenPlatform") as Material);
        Mats.Add(Resources.Load("BlackPlatform") as Material);
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpMult[(int)Colors.Red] = GameManager.Instance.getRedJumpForce();
        jumpMult[(int)Colors.Green] = GameManager.Instance.getGreenJumpForce();
        jumpMult[(int)Colors.Black] = 0;
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

        Colors randomColor = RandomizeColor();
        int colorInumerator = (int)randomColor;
        GameObject curPlatform = Instantiate(Platform, new Vector3(0, 0, 0), Quaternion.identity);
        
        Platform myPlat = AddPlatformComponent(curPlatform, randomColor);
        float Length = Random.Range(MinPlatformL, MaxPlatformL);    
        Material materialColor = Mats[colorInumerator];

        float xDistance = Random.Range(MinXDistance, MaxXDistance);
        float yDistance = Random.Range(MinYDistance, MaxYDistance);
        float x = lastPlatformPos.x + LastPlatformLength + xDistance;
        float y = lastPlatformPos.y + yDistance;
        float jump = jumpMult[colorInumerator] * jumpCoeff[colorInumerator];
        Vector3 pos = new Vector3(x, y, 0);

        myPlat.SetUp(pos, Length, materialColor, PlatformCounter, jump);

        lastPlatformPos = pos;
        LastPlatformLength = Length;
        PlatformCounter++;

        if(!GameManager.Instance.msgAddPlatform(curPlatform)) {
            Debug.Log("platform doesn't create");
        }
        
        yield return new WaitForSeconds(1);
        myCoroutine = null;
    }

    void StopSpawning()
    {

    }

    private Platform AddPlatformComponent(GameObject curPlatform, Colors color)
    {
        if (color == Colors.Black)
        {
            curPlatform.AddComponent<BlackedPlatform>();
            return curPlatform.GetComponent<BlackedPlatform>();
        }

        curPlatform.AddComponent<ColoredPlatform>();
        return curPlatform.GetComponent<ColoredPlatform>();
    }

        private Colors RandomizeColor()
    {
        float rnd = Random.Range(0.01f, 1.01f);
        //smallest chance number
        if (rnd <= spawnChanceBlack)
        {
            return Colors.Black;
        }
        //highest chance number
        else if (rnd > spawnChanceGreen)
        {
            return Colors.Green;
        }

        return Colors.Red;
        
    }
}
