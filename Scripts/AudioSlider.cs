using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _musicSlider.onValueChanged.AddListener((value) => {
            _audioSource.volume = value;
        });
    }
}
