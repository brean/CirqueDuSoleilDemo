using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSegments : MonoBehaviour {
    public List<GameObject> Segments;
    private bool SegmentsShown;
    private int currentSegment;

	// Use this for initialization
	private void Start () {
        SegmentsShown = false;
        currentSegment = 0;
        foreach (GameObject Segment in Segments)
        {
            Segment.SetActive(false);
        }
	}

    public void ToggleSegments()
    {
        if (SegmentsShown)
        {
            HideSegments(); 
        }
        else
        {
            StartShowSegments();
        }
    }

    public void HideSegments()
    {
        SegmentsShown = false;
        foreach (GameObject Segment in Segments)
        {
            Segment.SetActive(false);
        }
    }

    public void StartShowSegments()
    {
        HideSegments();
        SegmentsShown = true;
        currentSegment = 0;
        GameObject Segment = Segments[currentSegment];
        Segment.SetActive(true);
        Segment.transform.localScale = Vector3.one * .5f;
    }

    private void Update()
    {
        if (SegmentsShown && currentSegment < Segments.Count)
        {
            GameObject Segment = Segments[currentSegment];
            if (Segment.transform.localScale.x < 1f)
            {
                Vector3 scale = Segment.transform.localScale;
                Segment.transform.localScale = scale * 1.12f;
            } else
            {
                Segment.transform.localScale = Vector3.one;
                currentSegment++;
                if (currentSegment >= Segments.Count)
                {
                    return;
                }
                Segment = Segments[currentSegment];
                Segment.SetActive(true);
                Segment.transform.localScale = Vector3.one * .5f;
            }
        }
    }
}
