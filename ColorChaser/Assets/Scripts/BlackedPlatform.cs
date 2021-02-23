using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackedPlatform : Platform
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void JumpEffect()
    {
        GameManager.Instance.msgBlackPlatformHit();
    }
}