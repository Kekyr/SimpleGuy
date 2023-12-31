using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class YesButton : MonoBehaviour
{
    [SerializeField] private SFXSO _sfx;
    [SerializeField] private PlayerStatsSO _playerStats;
    [SerializeField] private Player _player;

    private Button _button;
    private Transform _canvas;
    private Audio _audio;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _canvas = transform.parent.parent;
        _audio = _canvas.gameObject.GetComponentInChildren<Audio>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _audio.Play(_sfx);
        _player.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        _playerStats.Rebirth();
    }
}