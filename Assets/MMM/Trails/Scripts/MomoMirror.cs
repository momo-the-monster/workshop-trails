using UnityEngine;
using System.Collections;


namespace mmm
{

    [ExecuteInEditMode]
    public class MomoMirror : MonoBehaviour
    {
        #region Variables
        public Shader SCShader;
        private Material SCMaterial;
        public bool bypass = false;
        public BlendModes blendMode;
        private BlendModes deltaBlendMode;
        public UnityEngine.UI.Text label;
        internal int blendModesCount;
        #endregion

        public enum BlendModes
        {
            FullA, FullB, Screen, Average, ColorMax, ColorMin, Difference, Inverted
        }

        #region Event Delegates
        public delegate void SwitchAction(BlendModes b);
        public static event SwitchAction OnSwitched;
        #endregion

        #region Properties
        Material material
        {
            get
            {
                if (SCMaterial == null)
                {
                    SCMaterial = new Material(SCShader);
                    SCMaterial.hideFlags = HideFlags.HideAndDontSave;
                }
                return SCMaterial;
            }
        }
        #endregion
        void Start()
        {
            SCShader = Shader.Find("Custom/MomoMirror");

            if (!SystemInfo.supportsImageEffects)
            {
                enabled = false;
                return;
            }

            UpdateLabel();

            blendModesCount = System.Enum.GetValues(typeof(BlendModes)).Length;

        }

        void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
        {
            if (SCShader != null && !bypass)
            {
                Graphics.Blit(sourceTexture, destTexture, material);
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }
        }

        void Update()
        {

#if UNITY_EDITOR
            if (Application.isPlaying != true)
            {
                SCShader = Shader.Find("Custom/MomoMirror");
            }

#endif

            if (Input.GetKeyDown(KeyCode.M))
            {
                bypass = !bypass;
            }

            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                int blendModeIndex = (int)blendMode + 1;
                if (blendModeIndex >= blendModesCount)
                {
                    blendModeIndex = 0;
                }
                blendMode = (BlendModes)blendModeIndex;
                SendBlendmodeChange(blendMode);
            }

            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                int blendModeIndex = (int)blendMode - 1;
                if (blendModeIndex < 0)
                {
                    blendModeIndex = blendModesCount - 1;
                }
                blendMode = (BlendModes)blendModeIndex;
                SendBlendmodeChange(blendMode);
            }

            if (deltaBlendMode != blendMode)
            {
                material.SetFloat("blendMode", (int)blendMode);
                UpdateLabel();
            }
            deltaBlendMode = blendMode;

        }

        void SendBlendmodeChange(BlendModes b)
        {
            if (OnSwitched != null)
                OnSwitched(b);
        }

        void UpdateLabel()
        {
            if (label != null)
            {
                label.text = "Blend: " + blendMode.ToString();
            }
        }

        void OnDisable()
        {
            if (SCMaterial)
            {
                DestroyImmediate(SCMaterial);
            }

        }


    }
}