using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // ���� ��� ���� ������ MusicManager, ���������� ����
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ��� ����� �����
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
