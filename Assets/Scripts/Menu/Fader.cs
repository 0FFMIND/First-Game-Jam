using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : UnitySingleton<Fader>
{
    public bool isDefeated = false;
    public void ChangeScene(string sceneName)
    {
        Transitioner.Instance.TransitionToScene(sceneName);
    }
}
