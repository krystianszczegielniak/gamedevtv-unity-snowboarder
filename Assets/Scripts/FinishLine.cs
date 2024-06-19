using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private float finishLevelDelay = 2.0f;

    [SerializeField]
    private ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("ReloadScene", finishLevelDelay);
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
}
