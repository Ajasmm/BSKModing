using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;


public class CustomLightingRenderManager : MonoBehaviour
{
    [SerializeField] Texture2D lightCookie;

    #region  Point Light Area
    public const string pointLightCountProperty = "_PointLightCount";

    public const string pointLightPositionProperty = "_PointLightPositions";
    public const string pointLightColorProperty = "_PointLightColors";
    public const string pointLightRangeProperty = "_PointLightRange";

    public const string cameraPositionProperty = "_CameraPosition";
    public const string maxDistanceProperty = "_MaxPointLightDistance";
    #endregion

    #region Head Light
    public const string headLightCountProperty = "_HeadLightCount";
    public const string headLightPositionProperty = "_HeadLightPositions";
    public const string headLightColorProperty = "_HeadLightColors";
    public const string headLightNearClipProperty = "_HeadLightNearClip";
    public const string headLightFarClipProperty = "_HeadLightFarClip";
    public const string headLightIntencityProperty = "_HeadLightIntencity";
    public const string headLightForwardPorperty = "_HeadLightForward";
    public const string headLightViewProjectionProperty = "_HeadLightViewProjection";
    public const string headLightCookiesProperty = "_HeadLightCookie";
    #endregion


    public static CustomLightingRenderManager instance;

    int maxLightCount = 20;
    float lightDistance = 250;

    Vector4[] pointLightPositionDatas;
    Vector4[] pointLightColorDatas;
    float[] pointLightRangeDatas;

    Vector4[] headLightPositionDatas;
    Vector4[] headLightColorDatas;
    float[] headLightIntencityDatas;
    Vector4[] headLightForwardDatas;
    float[] headLightNearClipDatas;
    float[] headLightFarClipDatas;
    Matrix4x4[] headLightViewProjectionDatas;



    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    public void Start()
    {
        CreateArrays(maxLightCount);
        Shader.SetGlobalTexture(headLightCookiesProperty, lightCookie);
        Shader.SetGlobalFloat(maxDistanceProperty, lightDistance);
    }

    private void CreateArrays(int maxLightCount)
    {
        pointLightPositionDatas = new Vector4[maxLightCount];
        pointLightColorDatas = new Vector4[maxLightCount];
        pointLightRangeDatas = new float[maxLightCount];

        headLightPositionDatas = new Vector4[maxLightCount];
        headLightColorDatas = new Vector4[maxLightCount];
        headLightIntencityDatas = new float[maxLightCount];
        headLightForwardDatas = new Vector4[maxLightCount];
        headLightNearClipDatas = new float[maxLightCount];
        headLightFarClipDatas = new float[maxLightCount];
        headLightViewProjectionDatas = new Matrix4x4[maxLightCount];
    }
    private void ClearArrays()
    {
        Array.Clear(pointLightPositionDatas, 0, pointLightPositionDatas.Length);
        Array.Clear(pointLightColorDatas, 0, pointLightColorDatas.Length);
        Array.Clear(pointLightRangeDatas, 0, pointLightRangeDatas.Length);

        Array.Clear(headLightPositionDatas, 0, headLightPositionDatas.Length);
        Array.Clear(headLightColorDatas, 0, headLightColorDatas.Length);
        Array.Clear(headLightIntencityDatas, 0, headLightIntencityDatas.Length);
        Array.Clear(headLightForwardDatas, 0, headLightForwardDatas.Length);
        Array.Clear(headLightNearClipDatas, 0, headLightNearClipDatas.Length);
        Array.Clear(headLightFarClipDatas, 0, headLightFarClipDatas.Length);
        Array.Clear(headLightViewProjectionDatas, 0, headLightViewProjectionDatas.Length);
    }

    public void LateUpdate()
    {
    }
}