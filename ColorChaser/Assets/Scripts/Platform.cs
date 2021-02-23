using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    private float PlatformLength;
    private Vector3 pos;
    private Material PlatformColor;
    private bool ColorToggle;
    private float timer;
    private float jumpMultiplyer;
    private int Id;

    private Color OriginalColor;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyPlatform());
    }

    public void SetUp(Vector3 newPos, float newLength, Material newColor, int newId, float newJumpMult)
    {
        pos = newPos;
        transform.position = newPos;
        PlatformLength = newLength;
        transform.localScale += new Vector3(newLength-1, 0, 0);
        PlatformColor = newColor;
        jumpMultiplyer = newJumpMult;

        meshRenderer.material = newColor;
        Id = newId;

        OriginalColor = meshRenderer.material.color;


    }

    public int getID()
    {
        return Id;
    }

    public float getJumpMultiplyer()
    {
        return jumpMultiplyer;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        JumpEffect();
    }

    public abstract void JumpEffect();

    IEnumerator DestroyPlatform()
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
        if(!isColor) {
            meshRenderer.material.SetColor("_Color", Color.black);
        }
        else {
            meshRenderer.material.SetColor("_Color", OriginalColor);
        }
    }

}
