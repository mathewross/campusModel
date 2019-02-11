using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopNavigation : MonoBehaviour
{
    public Follower follower;

    // Start is called before the first frame update
   public void stopNavigation()
    {
        follower.trail.Clear();
        follower.trail.enabled = false;
    }
}
