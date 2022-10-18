using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleView : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _offImg;

    public event Action<bool> onToggle;
    private void Awake()
    {
        _offImg.enabled = false;
    }

    private void Start()
    {
        _toggle.onValueChanged.AddListener(toggleValue =>
        {
            _offImg.enabled = !toggleValue;
            onToggle.Invoke(toggleValue);
        });
    }
}
