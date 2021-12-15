using UnityEngine;

public static class AnimatorExpand
{
    public static float GetAnimationClipLength(this Animator animator, string clipName)
    {
        if (null == animator || string.IsNullOrEmpty(clipName) || null == animator.runtimeAnimatorController)
            return 0;
        var ac = animator.runtimeAnimatorController;
        var tAnimationClips = ac.animationClips;
        if (null == tAnimationClips || tAnimationClips.Length <= 0) return 0;
        for (int tCounter = 0, tLen = tAnimationClips.Length; tCounter < tLen; tCounter++)
        {
            var tAnimationClip = ac.animationClips[tCounter];
            if (null != tAnimationClip && tAnimationClip.name == clipName)
                return tAnimationClip.length;
        }

        return 0f;
    }
}