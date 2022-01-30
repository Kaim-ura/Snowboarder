using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAfterCrash = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    private Transform snowboarder;
    private Vector3 resetPosition = Vector3.zero;
    private Quaternion resetRotation = Quaternion.Euler(0f, 0f, 0f);
    private bool hasCrashed = false;

    private void Start()
    {
        snowboarder = GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableConstrolers();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke(nameof(ResetState), delayAfterCrash);
        }
    }

    private void ResetState()
    {
        snowboarder.position = resetPosition;
        snowboarder.rotation = resetRotation;
        FindObjectOfType<PlayerController>().AnableControlers();
        hasCrashed = false;
    }
}
