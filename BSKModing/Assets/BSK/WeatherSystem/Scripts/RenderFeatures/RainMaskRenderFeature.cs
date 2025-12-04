using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;


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

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            const string passName = "RainMaskPass";

            if (wiperMaskTextureRT == null)
            {
                return;
            }

            UniversalCameraData camData = frameData.Get<UniversalCameraData>();

            if (!camData.camera.CompareTag("MainCamera"))
            {
                return;
            }

            var desc = new RenderTextureDescriptor(256, 256, UnityEngine.Experimental.Rendering.GraphicsFormat.R16_SFloat, 0, 3);
            CheckRT(desc);

            TextureHandle destination = renderGraph.ImportTexture(destinationRT);
            TextureHandle source = renderGraph.ImportTexture(sourceRT);

            RenderGraphUtils.BlitMaterialParameters parameters =
            new RenderGraphUtils.BlitMaterialParameters(source, destination, mat, 0);

            renderGraph.AddCopyPass(destination, source, "SourceCopy");
            renderGraph.AddBlitPass(parameters, passName: passName);

        }

        public void CheckRT(RenderTextureDescriptor targetDescriptor)
        {
            if (destinationRT == null)
            {
                destinationRT = RTHandles.Alloc(targetDescriptor, name: RainMaskRTName);
                sourceRT = RTHandles.Alloc(targetDescriptor, name: $"{RainMaskRTName}Source");
                Shader.SetGlobalTexture(Shader.PropertyToID(RainMaskRTName), destinationRT);
                return;
            }

            var size = destinationRT.GetScaledSize();
            if (size.x != targetDescriptor.width || size.y != targetDescriptor.height)
            {
                destinationRT.Release();
                destinationRT = RTHandles.Alloc(targetDescriptor, name: RainMaskRTName);
                sourceRT.Release();
                sourceRT = RTHandles.Alloc(targetDescriptor, name: $"{RainMaskRTName}Source");
                Shader.SetGlobalTexture(Shader.PropertyToID(RainMaskRTName), destinationRT);
            }
        }
    }

    RainMaskPass m_ScriptablePass;

    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new RainMaskPass();

        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;
        m_ScriptablePass.mat = new Material(Shader.Find("BSK/Rain/RainMaskBlitShader"));
        // m_ScriptablePass.mat = new Material(Shader.Find("BSK/NewImageEffectShader"));
    }
    void OnDisable()
    {
        if (m_ScriptablePass != null)
        {
            m_ScriptablePass.destinationRT?.Release();
            m_ScriptablePass.destinationRT = null;

            m_ScriptablePass.sourceRT?.Release();
            m_ScriptablePass.sourceRT = null;
        }
    }
    void OnDestroy()
    {
        if (m_ScriptablePass != null)
        {
            m_ScriptablePass.destinationRT?.Release();
            m_ScriptablePass.destinationRT = null;

            m_ScriptablePass.sourceRT?.Release();
            m_ScriptablePass.sourceRT = null;

            Destroy(m_ScriptablePass.mat);
        }
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}
