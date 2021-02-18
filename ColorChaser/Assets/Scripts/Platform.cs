using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float Length;
    // public float YCoord;
    // public float XCoord;
    public Vector3 pos;
    public string Color;
    public bool ColorToggle;
    public float timer;
    public float jumpMultiplyer;
    public int Id;

    Renderer m_Renderer;


    void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetUp()
    {
        transform.position = pos;
        transform.localScale += new Vector3(Length-1, 0,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnBecameInvisible()
    {
        //שיעלים את הפלטפורמה GameManager לשלוח הודעה ל
        //לשלוח את הפלטפורמה עצמה
    }

    void JumpEffect()
    {

    }

    void Destroy()
    {

    }
    void TurnBlack()
    {

    }
}
