using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    /// <summary>
    ///     播放结束事件
    /// </summary>
    [SerializeField] private UnityEvent onCompleteEvents;

    /// <summary>
    ///     播放结束状态 1-隐藏 2-销毁
    /// </summary>
    [SerializeField] private CompleteType completeType;

    private Animator animator;
    private float playTime;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        playTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;

        StartCoroutine(nameof(DelayClipComplete));
    }

    private IEnumerator DelayClipComplete()
    {
        yield return new WaitForSeconds(playTime);

        switch (completeType)
        {
            case CompleteType.Disappear:
                gameObject.SetActive(false);
                break;
            case CompleteType.Destroy:
                Destroy(gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        onCompleteEvents?.Invoke();
    }
}

public enum CompleteType
{
    Disappear,
    Destroy
}