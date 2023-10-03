using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    public List<bool> Signals = new List<bool>(5);
    
    public void SignalReceiver(float value)
    {
        if (timeline is not null) timeline.time = value;
    }

    public void SignalOn(int value)
    {
        for (int j = 0; j < Signals.Count; j++)
        {
            Signals[j] = false;
        }
        Signals[value] = true;
    }
    
    private void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            if (timeline is not null)
            {
                for (int j = 0; j < Signals.Count; j++)
                {
                    if (Signals[j])
                    {
                        AddValue(j);
                    }
                }
            }
        }
    }

    private void AddValue(int value)
    {
        switch (value)
        {
            case 0:
                timeline.time = 10.8333f;
                break;
            case 1:
                timeline.time = 32.0667f;
                break;
            case 2:
                timeline.time = 48.7333f;
                break;
            case 3:
                timeline.time = 79.9667f;
                break;
            case 4:
                timeline.time = 102.4333f;
                break;
            case 5:
                SceneManager.LoadSceneAsync(1);
                break;
        }
    }
}