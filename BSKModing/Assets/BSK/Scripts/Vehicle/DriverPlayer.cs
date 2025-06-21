using UnityEngine;
using BSK.Vehicles;
using Unity.Mathematics;
using BSK.Traffic;

[RequireComponent(typeof(Vehicle))]
public class DriverPlayer : MonoBehaviour
{
    [SerializeField] Vehicle vehicle;
    [SerializeField] VehicleLightManager vehicleLightManager;
    [SerializeField] VehicleAnimationManager vehicleAnimationController;
    [SerializeField] Horn horn;

    [SerializeField] bool isPlayer = true;
    [SerializeField] float distanceDriven;

    [SerializeField] public Transform[] doorsEntryPoint;

}
