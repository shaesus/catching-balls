using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnBallFall = new UnityEvent();

    public static void SendBallFall()
    {
        OnBallFall.Invoke();
    }
}
