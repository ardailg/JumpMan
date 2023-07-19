using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public ScrollingBackground scrollingBackground;

    public void StopBackground()
    {
        if (scrollingBackground != null)
        {
            scrollingBackground.enabled = false;
        }
    }
}
