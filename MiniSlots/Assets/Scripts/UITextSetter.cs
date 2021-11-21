using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextSetter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private GameEventListenerWithStringData _listener;

    private void Awake()
    {
        _listener.AddDelegateToUnityEvent(SetText);
        gameObject.SetActive(false);
    }

    public void SetText(string input)
    {
        _text.text = input;
        GetComponent<DisableGameObjectAfterDelay>().DisableGameObject();
    }
}
