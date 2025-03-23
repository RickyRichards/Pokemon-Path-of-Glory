using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PokeballMorph : MonoBehaviour
{
    private Animator animator;
    private Image ballImage;

    [SerializeField] private Sprite pokeballSprite;
    [SerializeField] private Sprite greatballSprite;
    [SerializeField] private float morphTime = 3.0f; // Adjust for timing

    public bool animationFinished = false; // Tracks when animation ends

    private void Start()
    {
        animator = GetComponent<Animator>();
        ballImage = GetComponent<Image>();
        gameObject.SetActive(false); // Start hidden
    }

    public void StartMorph()
    {
       // gameObject.SetActive(true); // Show Poké Ball
        animator.SetBool("Morph", true);
        StartCoroutine(ChangeSpriteAfterDelay(morphTime / 2));
        StartCoroutine(AnimationCompleteTimer(morphTime));
    }

    private IEnumerator ChangeSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ballImage.sprite = greatballSprite;
    }

    private IEnumerator AnimationCompleteTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        animationFinished = true; // Mark animation as complete
    }
}
