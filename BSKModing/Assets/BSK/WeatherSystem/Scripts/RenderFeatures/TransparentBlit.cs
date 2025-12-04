using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class TransparentBlit : ScriptableRendererFeature
{
    class TransparentBlitPass : ScriptableRenderPass
    {

        public RTHandle destinationRT = null;
        public const string TransparentBlitName = "_transperantBlit";

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            const string passName = "TransparentBlit";

            UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
            UniversalCameraData camData = frameData.Get<UniversalCameraData>();

            if (!camData.camera.CompareTag("MainCamera"))
                return;

            // var targetDescriptor = resourceData.cameraColor.GetDescriptor(renderGraph);
            var targetDescriptor = camData.cameraTargetDescriptor;
            CheckRT(targetDescriptor);

            TextureHandle destination = renderGraph.ImportTexture(destinationRT);
            TextureHandle source = resourceData.cameraColor;

            renderGraph.AddBlitPass(source, destination, Vector2.one, Vector2.zero, passName: passName);
        }

        private void CheckRT(RenderTextureDescriptor targetDescriptor)
        {
            if (destinationRT == null)
            {
                destinationRT = RTHandles.Alloc(targetDescriptor.width, targetDescriptor.height,
                name: TransparentBlitName,
                format: UnityEngine.Experimental.Rendering.GraphicsFormat.B10G11R11_UFloatPack32);
                Shader.SetGlobalTexture(Shader.PropertyToID(TransparentBlitName), destinationRT);
                return;
            }

            var size = destinationRT.GetScaledSize();
            if (size.x != targetDescriptor.width || size.y != targetDescriptor.height)
            {
                destinationRT.Release();
                destinationRT = RTHandles.Alloc(targetDescriptor.width, targetDescriptor.height,
                name: TransparentBlitName,
                format: UnityEngine.Experimental.Rendering.GraphicsFormat.B10G11R11_UFloatPack32);
                Shader.SetGlobalTexture(Shader.PropertyToID(TransparentBlitName), destinationRT);
            }
        }
    }

    TransparentBlitPass m_ScriptablePass;

    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new TransparentBlitPass();

        // Configures where the render pass should be injected.
        m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }
    void OnDisable()
    {
        if (m_ScriptablePass != null)
        {
            m_ScriptablePass.destinationRT?.Release();
            m_ScriptablePass.destinationRT = null;
        }
    }
    void OnDestroy()
    {
        if (m_ScriptablePass != null)
        {
            m_ScriptablePass.destinationRT?.Release();
            m_ScriptablePass.destinationRT = null;
        }
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}
