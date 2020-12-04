using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine.Windows.Speech;
using UnityEngine;

public class VoiceRecognizer : MonoBehaviour
{
    [SerializeField]
    bool isDebug;
    [SerializeField]
    RecognizeTarget[] targets;
    KeywordRecognizer recognizer;
    // Start is called before the first frame update
    void Awake()
    {
        string[] keys = new string[targets.Length];
        for(int i = 0; i < targets.Length; i++)
        {
            keys[i] = targets[i].text;
        }
        recognizer = new KeywordRecognizer(keys);
        recognizer.OnPhraseRecognized += OnPhraseRecognized;
        recognizer.Start();

    }



    void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (isDebug)
        {
            Debug.Log(args.text);
        }
        foreach (var t in targets)
        {
            if(t.text == args.text)
            {
                t.ev.Invoke();
                break;
            }
        }
    }
}
