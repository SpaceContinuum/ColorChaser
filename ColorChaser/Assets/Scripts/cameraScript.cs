using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

        //מירי את יכולה להתעלם מהסקריפט הזה הוא רק לבדיקות שלנו

    public Transform Target;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        if (Target == null)
        {
            Debug.LogError("No Target set for CameraFollow script");
            return;
        }

        _offset = new Vector3(-2.5f,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Target.position - _offset;

        transform.position = newPos;
    }
}
