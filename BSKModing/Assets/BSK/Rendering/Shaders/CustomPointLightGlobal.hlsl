#ifndef CAMERA_PARAMS_INCLUDED
#define CAMERA_PARAMS_INCLUDED

// Pragmas
#define MAX_ARRAY_SIZE 20

// Global parameters
float3 _CameraPosition;
half _MaxPointLightDistance;

half _PointLightCount;
float4 _PointLightPositions [MAX_ARRAY_SIZE];
half4 _PointLightColors [MAX_ARRAY_SIZE];
half _PointLightRange [MAX_ARRAY_SIZE];

// Texture parameter (must exist in ShaderGraph Blackboard)
TEXTURE2D(_PointLightTexture);
SAMPLER(sampler_PointLightTexture);

// Sample Light Texture
void GetLightColor_float(float2 uv, out float4 lightTexColor)
{
    lightTexColor = float4(0, 0, 0, 0);
}

// Camera Params
void GetCameraParams_float(out float3 cameraPos, out float maxDistance)
{
    cameraPos = _CameraPosition;
    maxDistance = _MaxPointLightDistance;
}

float inverseLerp(float a, float b, float value)
{
    return (value - a) / (b - a);
}
float WorldDither(float2 worldXZ)
{
    return frac(sin(dot(worldXZ, float2(12.9898,78.233))) * 43758.5453);
}

void GetLightColor_float(float3 pixelPosWS, float3 pixelDirWS, out float3 lightColor)
{
    #pragma multi_compile __ POINT_LIGHT_TEXTURE

    lightColor = float3(0, 0, 0);
    #if defined(POINT_LIGHT_TEXTURE)

    float3 camPos = _CameraPosition;
    
    float3 different = camPos - pixelPosWS;
    different.y = 0;
    half differntsSquared = dot(different, different);
    half rangeSquared = _MaxPointLightDistance * _MaxPointLightDistance;

    if(differntsSquared < rangeSquared){

        half invRange = rcp(_MaxPointLightDistance * 2);

        half2 uv;
        uv.x = different.x * invRange + 0.5;
        uv.y = - different.z * invRange + 0.5;

        uv = saturate(uv);

        half dotValue = dot(pixelDirWS, float3(0, 1, 0));
        dotValue = saturate(dotValue * 0.5 + 0.55);
        // lightColor = _PointLightTexture.Sample(sampler_PointLightTexture_Bilinear, uv) * dotValue;
        lightColor = _PointLightTexture.Sample(sampler_PointLightTexture, uv) * dotValue;
    }
    #endif
}



#endif