using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMaterial : MonoBehaviour {
    public Material Alternative;
    public Material Original;
    private Material Current;

    [Tooltip("behave like a global flag and also update other button materials")] // used for show building menu
    public List<AlternativeMaterial> alsoUpdate = null;

    public MeshRenderer Renderer;
	
	void Start () {
        // note that ?? does not work for GetComponentp!
        Renderer = Renderer == null ? GetComponent<MeshRenderer>() : Renderer;
        Original = Original == null ? Renderer.material : Original;
        Current = Original;
        Renderer.material = Original;
	}

    public void UpdateMaterial(Material mat)
    {
        if (Renderer == null || Renderer.material == null) return;
        if (alsoUpdate != null && alsoUpdate.Count > 0)
        {
            foreach (AlternativeMaterial otherMat in alsoUpdate)
            {
                // prevent endless loop, do not call UpdateMaterial!
                otherMat.Renderer.material = mat;
                otherMat.Current = mat;
            }
        }
        Renderer.material = mat;
        Current = mat;
    }

    public void ShowOriginal()
    {
        UpdateMaterial(Original);
    }

    public void ShowAlternative()
    {
        UpdateMaterial(Alternative);
    }
	
    public void SwitchMaterial()
    {
        UpdateMaterial(Current == Original ? Alternative : Original);
    }
}
