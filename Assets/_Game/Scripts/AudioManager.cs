using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    AudioSource audioSource;

    private void Awake() {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayAudioClip(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
