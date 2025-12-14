using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace BSK.WeatherSystem
{
    public class RainLayerRenderFeature : ScriptableRendererFeature
    {
        [SerializeField] string passName = "RainGlassRendering";
        [SerializeField] RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        [SerializeField] LayerMask targetLayer;

        RainLayerRenderPass pass;
        public class RainLayerRenderPass : ScriptableRenderPass
        {
            public string passName = string.Empty;
            public LayerMask targetLayer = -1;

            public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
            {
                
            }
        

            public class PassData
            {
                public RendererListHandle rendererListHandle;

            }
        }

        public override void Create()
        {
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
        }
    }
}