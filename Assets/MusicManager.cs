using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Если уже есть другой MusicManager, уничтожаем этот
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при смене сцены
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = MusicChanger.Volume2;
    }
}
