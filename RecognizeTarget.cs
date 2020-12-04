using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public struct RecognizeTarget
{
    public string text;
    public UnityEvent ev;
}
