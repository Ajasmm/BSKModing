using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BSK.Vehicles;
using BSK.WeatherSystem;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.Rendering.Universal;


public class CustomLightingRenderFeature : ScriptableRendererFeature
{

    public class CustomLightingRenderPass : ScriptableRenderPass
    {
        
    }


    [SerializeField] Texture2D lightCookie;
    [SerializeField] Shader pointLightTextureShader;
    private CustomLightingRenderPass pass;

    public override void Create()
    {
        

    }
    void OnDestroy()
    {
       
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        
    }
}