using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredPlatform : Platform
{


    protected override void JumpEffect()
    {
        GameManager.Instance.msgPlatformHit(getJumpMultiplyer());
    }

}
