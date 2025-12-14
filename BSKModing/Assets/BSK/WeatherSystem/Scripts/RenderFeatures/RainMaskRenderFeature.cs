using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using System.Diagnostics;


namespace BSK.WeatherSystem
{
    public class RainMaskRenderFeature : ScriptableRendererFeature
    {
        public class RainMaskPass : ScriptableRenderPass
        {
            public const string RainMaskRTName = "_rainMaskRT";
            public const string wiperMaskTexture = "_wiperMaskTexture";

            public static RTHandle wiperMaskTextureRT = null;
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            public static void RuntimeInitializeOnLoadMethod()
            {
                wiperMaskTextureRT = null;
            }


            public RTHandle destinationRT = null;
            public RTHandle sourceRT = null;

            public Material mat;
            public Material copyMat;

            public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
            {
                
            }

            public class PassData
            {
                public TextureHandle source;
                public TextureHandle destination;
                public Material mat;
            }
        }

        [SerializeField] Shader copyShader;
        [SerializeField] Shader wiperMaskUpdateShader;

        RainMaskPass m_ScriptablePass;

        /// <inheritdoc/>
        public override void Create()
        {
           
        }
        
        // Here you can inject one or multiple render passes in the renderer.
        // This method is called when setting up the renderer once per-camera.
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
           
        }
    }

    public class WiperMaskContextItem : ContextItem
    {
        public TextureHandle wiperMaskTexture;

        public override void Reset()
        {
            wiperMaskTexture = default;
        }
    }
}