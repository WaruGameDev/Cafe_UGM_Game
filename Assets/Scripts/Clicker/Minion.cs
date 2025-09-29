using UnityEngine;
using DG.Tweening;

public class Minion : MonoBehaviour
{
    void Start()
    {
        MinionManager.Instance.onMinionClicked += Jump;
    }
    public void Jump(float height, int jumps, float duration)
    {
        transform.DOJump(transform.position, height, jumps, duration, false);
    }
}
