using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackedPlatform : Platform
{


    protected override void JumpEffect()
    {
        GameManager.Instance.msgBlackPlatformHit();
    }
}