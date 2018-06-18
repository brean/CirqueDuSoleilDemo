using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ShowMenuOnTap : MonoBehaviour, IInputHandler
{
    public GameObject CircleNavi;

	// Use this for initialization
	void Start () {
        CircleNavi = (CircleNavi == null) ? GameObject.Find("UI/CircleNavi") : CircleNavi;
        InputManager.Instance.AddGlobalListener(gameObject);
	}

    public void OnInputDown(InputEventData eventData)
    {
        // check, if nothing has the focus
        FocusDetails? details = FocusManager.Instance.TryGetFocusDetails(eventData);
        if (details.HasValue && details.Value.Object == null)
        {
            CircleNavi.SetActive(true);
        }
    }

    public void OnInputUp(InputEventData eventData) { 
        // ignored
    }
}
