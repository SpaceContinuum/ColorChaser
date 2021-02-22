using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    private Text textComponent;

    void Awake() {
        textComponent = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneManagerScript.Instance.curGameScore = Mathf.Floor(Time.timeSinceLevelLoad);
        textComponent.text = Mathf.Floor(Time.timeSinceLevelLoad).ToString();
    }
}
