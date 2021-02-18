using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayer : MonoBehaviour
{

    //מירי את יכולה להתעלם מהסקריפט הזה הוא רק לבדיקות שלנו

protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            var pos = new Vector2(transform.position.x, transform.position.y);
            rb.MovePosition(pos + new Vector2(-0.1f, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            var pos = new Vector2(transform.position.x, transform.position.y);
            rb.MovePosition(pos + new Vector2(0.1f, 0));
        }
    }
}
