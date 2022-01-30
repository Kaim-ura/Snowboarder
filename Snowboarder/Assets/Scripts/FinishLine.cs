using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayAfterFinish = 1f;
    [SerializeField] ParticleSystem finishEfect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            finishEfect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(LoadScene), delayAfterFinish);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void ParticleExplosion()
    {

    }
}
