using UnityEngine;
using UnityEngine.Audio;

public class MixerSnapshotTrigger : MonoBehaviour
{
    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot caveSnapshot;
    public float transitionTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            caveSnapshot.TransitionTo(transitionTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            normalSnapshot.TransitionTo(transitionTime);
        }
    }
}