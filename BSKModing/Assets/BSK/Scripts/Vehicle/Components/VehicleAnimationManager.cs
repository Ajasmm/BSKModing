using UnityEngine;

namespace BSK.Vehicles
{
    public class VehicleAnimationManager : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] float wiperNormalSpeed = 1;
        [SerializeField] float wiperFastSpeed = 2;

        public const string wiperStateKey = "Wiper";
        public const string wiperSpeedKey = "WiperSpeed";
        public const string doorStateKey = "Door";

        private int wiperStateID;
        private int wiperSpeedID;
        private int doorStateID;

        private WiperModes wiperMode = WiperModes.OFF;
        private ToggleModes doorMode = ToggleModes.OFF;

        private void OnEnable()
        {
            wiperStateID = Animator.StringToHash(wiperStateKey);
            wiperSpeedID = Animator.StringToHash(wiperSpeedKey);
            doorStateID = Animator.StringToHash(doorStateKey);
        }

        private void Start()
        {
            SetWiperMode(wiperMode);
            SetDoorMode(doorMode);
        }

        public void SetWiperMode(WiperModes wiperMode)
        {
            this.wiperMode = wiperMode;
            switch (wiperMode)
            {
                case WiperModes.OFF:
                    animator.SetBool(wiperStateID, false);
                    break;
                case WiperModes.NORMAL:
                    animator.SetBool(wiperStateID, true);
                    animator.SetFloat(wiperSpeedID, wiperNormalSpeed);
                    break;
                case WiperModes.HIGH:
                    animator.SetBool(wiperStateID, true);
                    animator.SetFloat(wiperSpeedID, wiperFastSpeed);
                    break;
            }
        }
        public void SetDoorMode(ToggleModes doorMode)
        {
            this.doorMode = doorMode;
            switch (doorMode)
            {
                case ToggleModes.OFF:
                    animator.SetBool(doorStateID, false);
                    break;
                case ToggleModes.ON:
                    animator.SetBool(doorStateID, true);
                    break;
            }
        }
    }
}