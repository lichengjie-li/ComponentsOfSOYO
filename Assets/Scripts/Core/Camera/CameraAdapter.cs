using System;
using UnityEngine;

public class CameraAdapter : SingletonMono<CameraAdapter>
{
    private const float BgSize = 20.48f;

    /// <summary>
    ///     正交相机自适应背景公式参数
    ///     todo：不同情况具体适应，待完善
    /// </summary>
    private const float Proportion = 2f;

    [SerializeField] private CameraProjection cameraProjection;

    /// <summary>
    ///     当屏幕比例发生变化时，广播当前【宽高比】
    /// </summary>
    [SerializeField] private FloatEventChannelSO onRatioChangedEvent;

    private EventListener<float> listener;
    private float ratio = -1;

    public Camera MainCam { get; private set; }
    private static float Scale => -BgSize / 2 / Mathf.Tan(30 * Mathf.Deg2Rad);

    private void Awake()
    {
        MainCam = Camera.main;
    }

    private void Update()
    {
        ratio = (float) Screen.width / Screen.height;

        switch (cameraProjection)
        {
            case CameraProjection.Perspective:
                var z = ratio < 1 ? Scale : Scale * Screen.height / Screen.width;
                transform.position = new Vector3(0, 0, z);
                break;
            case CameraProjection.Orthographic:
                MainCam.orthographicSize = ratio < 1 ? BgSize / Proportion : BgSize / Proportion / ratio;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        listener.Value = ratio;
    }

    private void OnEnable()
    {
        listener = new EventListener<float>();
        listener.OnValueChangedEvent += OnRatioChanged;
    }

    private void OnDisable()
    {
        listener.OnValueChangedEvent -= OnRatioChanged;
    }

    private void OnRatioChanged(float value)
    {
        onRatioChangedEvent.Raise(value);
    }
}

public enum CameraProjection
{
    Perspective,
    Orthographic
}