using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class CameraTouchPad : MonoBehaviour
{
    [SerializeField] float DPI;
    [SerializeField] float clickDelay = 0.3f, deltadelay;

    [Header("Invert")]
    [SerializeField] bool invertX;
    [SerializeField] bool invertY;
    [SerializeField] bool invertScroll;
    [SerializeField] bool invertTouchZoom;

    [Header("Sencitivity")]
    [SerializeField] float sencitivityX = 1000;
    [SerializeField] float sencitivityY = 1000;
    [SerializeField] float sencitivityScroll = 0.1f;
    [SerializeField] float sencitivityTouchZoom = 1000;


}
