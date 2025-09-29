using UnityEngine;
using DG.Tweening;

public class AnimationDoTween : MonoBehaviour
{
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX(transform.position.x + 3f, 2f).SetEase(Ease.InOutSine));
        mySequence.Append(transform.DORotate(new Vector3(0, 360, 0), 3f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        mySequence.Append(transform.DOScale(transform.localScale * 2f, 1.5f).SetEase(Ease.InOutSine));
        mySequence.AppendCallback(() => Debug.Log("Animation Complete!"));
        mySequence.SetLoops(-1, LoopType.Yoyo);
    }
}
