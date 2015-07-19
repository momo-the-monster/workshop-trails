using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

namespace mmm
{

    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class MomoMirror : PostEffectsBase
    {
        public Shader mirrorShader = null;
        private Material mirrorMaterial = null;

        public bool bypass = false;
        public KeyCode triggerNext = KeyCode.RightBracket;
        public KeyCode triggerPrevious = KeyCode.LeftBracket;
        public BlendModes blendMode;
        private BlendModes deltaBlendMode;
        internal int blendModesCount;

        public enum BlendModes
        {
            FullA, FullB, Screen, Average, ColorMax, ColorMin, Difference, Inverted
        }

        #region Event Delegates
        public delegate void SwitchAction(BlendModes b);
        public static event SwitchAction OnSwitched;
        #endregion

        public override bool CheckResources()
        {
            CheckSupport(false);

            mirrorMaterial = CheckShaderAndCreateMaterial(mirrorShader, mirrorMaterial);

            if (!isSupported)
                ReportAutoDisable();
            return isSupported;
        }
        
        void Awake()
        {
            blendModesCount = System.Enum.GetValues(typeof(BlendModes)).Length;
        }

        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (CheckResources() == false)
            {
                Graphics.Blit(source, destination);
                return;
            }

            if (mirrorShader != null && !bypass)
            {
                Graphics.Blit(source, destination, mirrorMaterial);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }

        void Update()
        {

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
                mirrorMaterial.SetFloat("blendMode", (int)blendMode);
            }
            deltaBlendMode = blendMode;

        }

        void SendBlendmodeChange(BlendModes b)
        {
            if (OnSwitched != null)
                OnSwitched(b);
        }

        void OnDisable()
        {
            if (mirrorMaterial)
            {
                DestroyImmediate(mirrorMaterial);
            }

        }


    }
}