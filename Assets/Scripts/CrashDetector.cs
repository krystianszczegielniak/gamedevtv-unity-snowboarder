using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    private float restartLevelDelay = 1.0f;

    [SerializeField]
    private ParticleSystem crashEffect;

    [SerializeField]
    private AudioClip crashSfx;

    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed    )
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            Invoke("ReloadScene", restartLevelDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
}
