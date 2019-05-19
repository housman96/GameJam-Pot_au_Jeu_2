using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class Fuite : MonoBehaviour
{
    private CharacterAnimationController animationController;
    private Vector3 lastPosition;
    private AIDestinationSetter destinationSetter;
    private AILerp lerp;
    public bool isInFuite = false;
    public Transform repliPosition;
    public GameObject camera;
    public Image imageFondu;
    public AudioClip cryClip;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<CharacterAnimationController>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        lerp = GetComponent<AILerp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInFuite)
        {
            Vector2 currentInput = new Vector2(0, 0);
            if ((transform.position - lastPosition).x > 0.01)
                currentInput.x = 1;
            if ((transform.position - lastPosition).x < -0.01)
                currentInput.x = -1;
            if ((transform.position - lastPosition).y > 0.01)
                currentInput.y = 1;
            if ((transform.position - lastPosition).y < -0.01)
                currentInput.y = -1;
            animationController.input = currentInput;
            lastPosition = transform.position;
        }
    }

    public void launchFuite()
    {
        GetComponent<CharacterInputController>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        destinationSetter.target = repliPosition;
        lerp.enabled = false;
        lerp.enabled = true;
        lastPosition = transform.position;
        isInFuite = true;
        camera.SetActive(false);
        StartCoroutine("fadeOut");
        StartCoroutine("cry");
    }

    public IEnumerator fadeOut()
    {
        while (imageFondu.color.a < 1)
        {
            imageFondu.color = new Color(imageFondu.color.r, imageFondu.color.g, imageFondu.color.b, imageFondu.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        camera.SetActive(true);
    }

    public IEnumerator cry()
    {
        AudioSource listener = gameObject.AddComponent<AudioSource>();
        listener.playOnAwake = false;
        listener.clip = cryClip;
        listener.loop = false;
        listener.volume = 0.4f;
        listener.Play();
        yield return new WaitUntil(() => !listener.isPlaying);
        Destroy(listener);
    }
}
