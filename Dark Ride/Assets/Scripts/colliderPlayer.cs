using UnityEngine;

public class MusicStageTrigger : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioSource goofySource;
    public AudioSource finalSource;

    public int stage; 
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        if (stage == 1)
        {
            if (ambientSource.isPlaying)
                ambientSource.Stop();

            goofySource.Play();
        }
        else if (stage == 2)
        {
            if (goofySource.isPlaying)
                goofySource.Stop();

            finalSource.Play();
        }
    }
}