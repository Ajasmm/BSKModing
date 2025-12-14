#ifndef VEHICLE_HEAD_LIGHT_INCLUDED
#define VEHICLE_HEAD_LIGHT_INCLUDED

#define MAX_ARRAY_SIZE 20

// Global parameters
float _HeadLightCount;
float4 _HeadLightPositions[MAX_ARRAY_SIZE];
float4 _HeadLightColors[MAX_ARRAY_SIZE];
float _HeadLightIntencity[MAX_ARRAY_SIZE];
float4 _HeadLightForward[MAX_ARRAY_SIZE];
float _HeadLightNearClip[MAX_ARRAY_SIZE];
float _HeadLightFarClip[MAX_ARRAY_SIZE];
float4x4 _HeadLightViewProjection[MAX_ARRAY_SIZE];

// Texture parameter (must exist in ShaderGraph Blackboard)
TEXTURE2D(_HeadLightCookie);
SAMPLER(sampler_HeadLightCookie);


void GetHeadLightColor_float(float3 pixelPos, float3 pixelNormalWS, out float4 lightColor)
{
    lightColor = float4(0,0,0,1);
    
    for(int i = 0; i < _HeadLightCount; i++)
    {
        float4 lightSpace = mul(_HeadLightViewProjection[i], float4(pixelPos, 1));
        // Perspective divide
        float3 ndc = lightSpace.xyz / lightSpace.w;
        
        // Inside projection bounds?
        half boundMask = step(-1, ndc.x) * step(ndc.x, 1);
        half boundMaskY = step(-1, ndc.y) * step(ndc.y, 1);
        half boundMaskZ = step(-1, ndc.z) * step(ndc.z, 1);
        boundMask = boundMask * boundMaskY * boundMaskZ;

        // if (ndc.x < -1 || ndc.x > 1 || ndc.y < -1 || ndc.y > 1 ||  ndc.z < -1 || ndc.z > 1)
        // continue;
        
        // Convert to UV
        half3 normalizedPos = ndc.xyz * 0.5 + 0.5;
        half2 uv = normalizedPos.xy;
        
        // View-space depth (positive)
        float fade = 1 - normalizedPos.z;
        fade = saturate(fade);
        
        half3 lightDirection = _HeadLightForward[i].xyz;
        half dotValue = dot(lightDirection, pixelNormalWS);
        dotValue *= -1;
        dotValue += 0.5;
        dotValue = saturate(dotValue);

        half cookie = _HeadLightCookie.Sample(sampler_HeadLightCookie, uv);
    
        half atten = fade * _HeadLightIntencity[i];

        half intensity = atten * cookie * dotValue * boundMask ;
        lightColor.rgb += intensity * _HeadLightColors[i].rgb;

    }
}

#endif