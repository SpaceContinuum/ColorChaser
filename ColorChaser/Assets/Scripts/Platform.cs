using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    private float Length;
    // public float YCoord;
    // public float XCoord;
    private Vector3 pos;
    private Material Color;
    private bool ColorToggle;
    private float timer;
    private float jumpMultiplyer;
    private int Id;

    void Awake()
    {
        StartCoroutine(Destroy());
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetUp(Vector3 newPos, float newLength, Material newColor, int newId)
    {
        transform.position = newPos;
        transform.localScale += new Vector3(newLength-1, 0, 0);
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = newColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getID()
    {
        return Id;
    }

    void JumpEffect()
    {

    }

    IEnumerator Destroy()
    {
        //waitForSeconds(6 * spawn interval);
        yield return new WaitForSeconds(6);
        
        if(GameManager.Instance.msgRemovePlatform(Id)) {
            Destroy(gameObject);
        }
        else {
            Debug.Log("platform doesn't destroy");
        }
        
    }
    public void TurnColor(bool isColor)
    {
        //if isColor true (colorize)
        //if isColor false (turn black)

    }


    public void someFunc() {
        Debug.Log("Platform");
    }


}
