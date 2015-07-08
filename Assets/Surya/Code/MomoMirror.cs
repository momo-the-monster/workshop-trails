using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MomoMirror : MonoBehaviour {
	#region Variables
	public Shader SCShader;
	private Material SCMaterial;
    public bool bypass = false;
    public BlendModes blendMode;
    private BlendModes deltaBlendMode;
	#endregion

    public enum BlendModes
    {
        FullA, FullB, Screen, Average, ColorMax, ColorMin, Difference, Inverted
    }
	
	#region Properties
	Material material
	{
		get
		{
			if(SCMaterial == null)
			{
				SCMaterial = new Material(SCShader);
				SCMaterial.hideFlags = HideFlags.HideAndDontSave;	
			}
			return SCMaterial;
		}
	}
	#endregion
	void Start () 
	{
		SCShader = Shader.Find("Custom/MomoMirror");

		if(!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
	}
	
	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
	{
        material.SetFloat("blendMode", (int)blendMode);

		if(SCShader != null && !bypass)
		{
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);	
		}
		
		
	}
	
	[ExecuteInEditMode]
	void Update () 
	{

		#if UNITY_EDITOR
		if (Application.isPlaying!=true)
		{
			SCShader = Shader.Find("Custom/MomoMirror");

		}

		#endif

        if (Input.GetKeyDown(KeyCode.M))
        {
            bypass = !bypass;
        }

	}
	
	void OnDisable ()
	{
		if(SCMaterial)
		{
			DestroyImmediate(SCMaterial);	
		}
		
	}
	
	
}