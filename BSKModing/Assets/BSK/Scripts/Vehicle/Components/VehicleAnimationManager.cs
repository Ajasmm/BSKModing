using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace BSK.Vehicles
{
    public class VehicleAnimationManager : MonoBehaviour
    {
        [SerializeField] Animator animator;

        [Header("Door")]

        [SerializeField] UnityEvent OnDoorOpen;
        [SerializeField] UnityEvent OnDoorClose;

        [Header("Wiper")]
        [SerializeField] float wiperNormalSpeed = 1;
        [SerializeField] float wiperFastSpeed = 2;
        [SerializeField] UnityEvent OnWiperOnNormal;
        [SerializeField] UnityEvent OnWiperOnFast;
        [SerializeField] UnityEvent OnWiperOff;


        [Header("Wiper Rain mask")]
        [SerializeField] Texture wiperMaskTexture;
        [SerializeField] string wiperPosPropertyName = "_WiperPos";
        [SerializeField] string wiperOnPropertyName = "_WiperOn";
        [SerializeField] string wiperAnimationStateName = "Anim_BSK1_Wiper ON";

        [Header("Additional Animations")]
        [SerializeField] public bool enableAnimation1;
        [SerializeField] public bool enableAnimation2;
        [SerializeField] public bool enableAnimation3;

        [SerializeField] public UnityEvent OnAnimation1On;
        [SerializeField] public UnityEvent OnAnimation1Off;
        [SerializeField] public UnityEvent OnAnimation2On;
        [SerializeField] public UnityEvent OnAnimation2Off;
        [SerializeField] public UnityEvent OnAnimation3On;
        [SerializeField] public UnityEvent OnAnimation3Off;

        public const string wiperStateKey = "Wiper";
        public const string wiperSpeedKey = "WiperSpeed";
        public const string doorStateKey = "Door";

        public const string anim1 = "anim1";
        public const string anim2 = "anim2";
        public const string anim3 = "anim3";

        private int anim1Id, anim2Id, anim3Id;

        private int wiperStateID;
        private int wiperSpeedID;
        private int doorStateID;

        private int wiperPosPropertyID;
        private int wiperOnPropertyID;
        private int wiperAnimationStateHash;

        private WiperModes wiperMode = WiperModes.OFF;
        private ToggleModes doorMode = ToggleModes.OFF;
        private ToggleModes anim1Mode = ToggleModes.OFF;
        private ToggleModes anim2Mode = ToggleModes.OFF;
        private ToggleModes anim3Mode = ToggleModes.OFF;

        RTHandle wiperMaskRTHandle = null;


        private void OnEnable()
        {
            wiperStateID = Animator.StringToHash(wiperStateKey);
            wiperSpeedID = Animator.StringToHash(wiperSpeedKey);
            doorStateID = Animator.StringToHash(doorStateKey);

            anim1Id = Animator.StringToHash(anim1);
            anim2Id = Animator.StringToHash(anim2);
            anim3Id = Animator.StringToHash(anim3);

            RTHandleSystem rtSystem = new RTHandleSystem();
            rtSystem.Initialize(256, 256);

            wiperMaskRTHandle = rtSystem.Alloc(wiperMaskTexture);
            RainMaskRenderFeature.RainMaskPass.wiperMaskTextureRT = wiperMaskRTHandle;
            Shader.SetGlobalTexture(Shader.PropertyToID(RainMaskRenderFeature.RainMaskPass.wiperMaskTexture), wiperMaskRTHandle);
            // Graphics.Blit(wiperMaskTexture, wiperMaskRTHandle);

        }

        private void Start()
        {
            SetWiperMode(wiperMode);
            SetDoorMode(doorMode);
            SetAnim1Mode(anim1Mode);
            SetAnim2Mode(anim2Mode);
            SetAnim3Mode(anim3Mode);


            wiperPosPropertyID = Shader.PropertyToID(wiperPosPropertyName);
            wiperOnPropertyID = Shader.PropertyToID(wiperOnPropertyName);
            wiperAnimationStateHash = Animator.StringToHash(wiperAnimationStateName);
        }

        void OnDestroy()
        {
            if (wiperMaskRTHandle != null)
            {
                if (RainMaskRenderFeature.RainMaskPass.wiperMaskTextureRT == wiperMaskRTHandle)
                    RainMaskRenderFeature.RainMaskPass.wiperMaskTextureRT = null;
                wiperMaskRTHandle.Release();
            }
        }
        void Update()
        {
            UpdateWiperPosInMask();
        }

        public void SetWiperMode(WiperModes wiperMode)
        {
            this.wiperMode = wiperMode;
            switch (wiperMode)
            {
                case WiperModes.OFF:
                    animator.SetBool(wiperStateID, false);
                    OnWiperOff?.Invoke();
                    break;
                case WiperModes.NORMAL:
                    animator.SetBool(wiperStateID, true);
                    animator.SetFloat(wiperSpeedID, wiperNormalSpeed);
                    OnWiperOnNormal?.Invoke();
                    break;
                case WiperModes.HIGH:
                    animator.SetBool(wiperStateID, true);
                    animator.SetFloat(wiperSpeedID, wiperFastSpeed);
                    OnWiperOnFast?.Invoke();
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
                    OnDoorClose?.Invoke();
                    break;
                case ToggleModes.ON:
                    animator.SetBool(doorStateID, true);
                    OnDoorOpen?.Invoke();
                    break;
            }
        }
        public void UpdateWiperPosInMask()
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            bool wiperState = stateInfo.IsName(wiperAnimationStateName) || wiperMode != WiperModes.OFF;

            if (wiperState)
            {
                var wiperAnimationPos = stateInfo.normalizedTime * 2 - 1;
                if (wiperAnimationPos < 0)
                    wiperAnimationPos *= -1;

                wiperAnimationPos = 1 - wiperAnimationPos;
                Shader.SetGlobalFloat(wiperPosPropertyID, wiperAnimationPos);
            }

            Shader.SetGlobalFloat(wiperOnPropertyID, wiperState ? 1 : 0);
        }

        public void SetAnim1Mode(ToggleModes animState)
        {
            anim1Mode = animState;
            bool state = animState == ToggleModes.ON;
            animator.SetBool(anim1Id, state);
            try
            {
                if (state)
                    OnAnimation1On?.Invoke();
                else
                    OnAnimation1Off?.Invoke();
            }
            catch
            {

            }

        }
        public void SetAnim2Mode(ToggleModes animState)
        {
            anim2Mode = animState;
            bool state = animState == ToggleModes.ON;
            animator.SetBool(anim2Id, state);
            try
            {
                if (state)
                    OnAnimation2On?.Invoke();
                else
                    OnAnimation2Off?.Invoke();
            }
            catch
            {

            }
        }
        public void SetAnim3Mode(ToggleModes animState)
        {
            anim3Mode = animState;
            bool state = animState == ToggleModes.ON;
            animator.SetBool(anim3Id, state);
            try
            {
                if (state)
                    OnAnimation3On?.Invoke();
                else
                    OnAnimation3Off?.Invoke();
            }
            catch
            {

            }
        }

    }
}