using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float smoothTime = 0.5f;

    private bool camPosTransitioning;
    private Vector3 velocity;
    private Vector3 CamPos => transform.position;

    private void Update()
    {
        if (camPosTransitioning)
        {
            // LerpToNextPosition();
        }
    }

    /// <summary>
    ///     缓动到下一个位置，在 Update中执行
    /// </summary>
    private void LerpToNextPosition(Vector3 nextPos)
    {
        // 重置速度，以便在中途切换目标点位置不会偏移
        velocity = Vector3.zero;

        transform.position = Vector3.SmoothDamp(CamPos, nextPos, ref velocity, smoothTime);

        // todo: 根据不同情况，设置达到判断
        if (Vector3.Distance(CamPos, nextPos) < 0.01f) camPosTransitioning = false;
    }
}