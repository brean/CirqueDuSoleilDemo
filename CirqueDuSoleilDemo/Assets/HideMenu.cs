using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour {

    public GameObject CircleNavi;

    // Use this for initialization
    void Start()
    {
        CircleNavi = (CircleNavi == null) ? GameObject.Find("UI/CircleNavi") : CircleNavi;
    }

    // Update is called once per frame
    public void Hide ()
    {
        CircleNavi.SetActive(false);
    }

    public void Show()
    {
        CircleNavi.SetActive(true);
    }
}
