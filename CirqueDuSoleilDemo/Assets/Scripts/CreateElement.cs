using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Element {
    [SerializeField]
    public string Name;
    [SerializeField]
    public GameObject Prefab;
}

public class CreateElement : MonoBehaviour {
    [SerializeField]
    public List<Element> Prefabs;

    public GameObject CircleNavi;

	// Use this for initialization
	void Start () {
        CircleNavi = (CircleNavi == null) ? GameObject.Find("UI/CircleNavi") : CircleNavi;
	}
	
	// Update is called once per frame
	public void Create(string name) {
        CircleNavi.SetActive(false);
        foreach (Element prefab in Prefabs) {
            if (prefab.Name == name)
            {
                GameObject inst = Instantiate(prefab.Prefab);
            }
        }
        
	}
}
