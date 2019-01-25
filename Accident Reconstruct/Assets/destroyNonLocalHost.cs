using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

public class destroyNonLocalHost : NetworkBehaviour
{
    public GameObject obj;
    private void Start()
    {
        if (!isLocalPlayer)
        {
            print("ffofof");
            Destroy(obj);
        }
    }
}
