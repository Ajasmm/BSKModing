using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;

namespace BSK.WeatherSystem
{
    public class TransparentBlit : ScriptableRendererFeature
    {
        public class TransparentBlitPass : ScriptableRenderPass
        {
                       public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
            {
                
            }
        }

        [SerializeField] Shader transparencyBlitShader;

        TransparentBlitPass m_ScriptablePass;

        /// <inheritdoc/>
        public override void Create()
        {
            
        }
        // Here you can inject one or multiple render passes in the renderer.
        // This method is called when setting up the renderer once per-camera.
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            
        }

        public class TransparentBlitContextItem : ContextItem
        {
            public TextureHandle transparentBlitTexture;

            public override void Reset()
            {
                transparentBlitTexture = default;
            }
        }
    }
}