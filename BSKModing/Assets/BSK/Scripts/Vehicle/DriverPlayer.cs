using UnityEngine;
using BSK.Vehicles;
using Unity.Mathematics;
using BSK.Traffic;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Permissions;
using UnityEngine.Events;

[RequireComponent(typeof(Vehicle))]
public class DriverPlayer : MonoBehaviour
{
    [SerializeField] Vehicle vehicle;
    [SerializeField] VehicleLightManager vehicleLightManager;
    [SerializeField] VehicleAnimationManager vehicleAnimationController;


    [SerializeField] bool isPlayer = true;
    [SerializeField] double distanceDriven;
    [SerializeField] double fuleInHand;

    [Header("Door entry point")]
    [SerializeField] public Transform[] doorsEntryPoint;


    public static float speed;
}
