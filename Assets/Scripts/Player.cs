using DG.Tweening;
using Testers;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private CubeStack _cubeStack;
   [SerializeField] private StackNewCubeTrigger _stackNewCubeTrigger;
   [SerializeField] private PlayerAnimator _playerAnimator;
   private void Awake()
   {
      _stackNewCubeTrigger.OnPickup += OnPickup;
   }

   private void OnPickup(GameObject cube)
   {
      if (cube.TryGetComponent<TweenRef>(out TweenRef tweenRef))
      {
         tweenRef.Tween.Kill();
      }
      _cubeStack.Add(cube);
      _playerAnimator.Jump(_cubeStack.Count);
   }
}
