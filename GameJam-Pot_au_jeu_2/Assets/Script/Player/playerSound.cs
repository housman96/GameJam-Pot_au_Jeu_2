using UnityEngine;

public class playerSound : MonoBehaviour
{

    public AudioSource sourceStep;

    public AudioSource sourceSword;

    public AudioSource sourceBowStart;

    public AudioSource sourceBowEnd;

    public AudioClip[] stepClip;

    public AudioClip[] swordClip;

    public AudioClip[] bowStartClip;

    public AudioClip[] bowReleaseClip;

    // Use this for initialization
    void Start()
    {
        sourceStep = gameObject.AddComponent<AudioSource>();
        sourceSword = gameObject.AddComponent<AudioSource>();
        sourceBowStart = gameObject.AddComponent<AudioSource>();
        sourceBowEnd = gameObject.AddComponent<AudioSource>();

        sourceStep.playOnAwake = false;
        sourceSword.playOnAwake = false;
        sourceBowStart.playOnAwake = false;
        sourceBowEnd.playOnAwake = false;

        sourceStep.loop = false;
        sourceSword.loop = false;
        sourceBowStart.loop = false;
        sourceBowEnd.loop = false;

        sourceStep.volume = 0.5f;
        sourceSword.volume = 0.25f;
        sourceBowStart.volume = 1f;
        sourceBowEnd.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void stepSound()
    {
        if (stepClip.Length > 1 && (transform.parent.parent.tag == "Player1" || transform.parent.parent.tag == "Player2") && !transform.parent.parent.GetComponent<Fuite>().isInFuite)
        {
            sourceStep.Stop();
            int clipIndex = Random.Range(0, stepClip.Length);
            while (sourceStep.clip == stepClip[clipIndex])
            {
                clipIndex = Random.Range(0, stepClip.Length);
            }
            sourceStep.clip = stepClip[clipIndex];
            sourceStep.Play();
        }
    }

    public void swordSound()
    {
        if (swordClip.Length > 1 && !sourceSword.isPlaying)
        {
            sourceSword.Stop();
            int clipIndex = Random.Range(0, swordClip.Length);
            while (sourceSword.clip == swordClip[clipIndex])
            {
                clipIndex = Random.Range(0, swordClip.Length);
            }
            sourceSword.clip = swordClip[clipIndex];
            sourceSword.Play();
        }
    }

    public void bowStart()
    {
        if (bowStartClip.Length > 1 && !sourceBowStart.isPlaying)
        {
            sourceBowStart.Stop();
            int clipIndex = Random.Range(0, bowStartClip.Length);
            while (sourceBowStart.clip == bowStartClip[clipIndex])
            {
                clipIndex = Random.Range(0, bowStartClip.Length);
            }
            sourceBowStart.clip = bowStartClip[clipIndex];
            sourceBowStart.Play();
        }


        if (bowStartClip.Length == 1 && !sourceBowStart.isPlaying)
        {
            sourceBowStart.Stop();
            sourceBowStart.clip = bowStartClip[0];
            sourceBowStart.Play();
        }
    }

    public void bowRelease()
    {
        if (bowReleaseClip.Length > 1 && !sourceBowEnd.isPlaying)
        {
            sourceBowEnd.Stop();
            int clipIndex = Random.Range(0, bowReleaseClip.Length);
            while (sourceBowEnd.clip == bowReleaseClip[clipIndex])
            {
                clipIndex = Random.Range(0, bowReleaseClip.Length);
            }
            sourceBowEnd.clip = bowReleaseClip[clipIndex];
            sourceBowEnd.Play();
        }

        if (bowReleaseClip.Length == 1 && !sourceBowEnd.isPlaying)
        {
            sourceBowEnd.Stop();
            sourceBowEnd.clip = bowReleaseClip[0];
            sourceBowEnd.Play();
        }
    }
}
