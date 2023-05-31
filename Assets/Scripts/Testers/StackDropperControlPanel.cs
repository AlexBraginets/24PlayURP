using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Testers
{
    public class StackDropperControlPanel : MonoBehaviour
    {
        [SerializeField] private StackDropperTester _stackDropperTester;
        [SerializeField] private Button _dropButton;
        [SerializeField] private StackDropperCubeSelector _stackDropperCubeSelector;
        private void Awake()
        {
            _dropButton.onClick.AddListener(Drop);
        }

        private void Drop()
        {
            List<int> hitIndices = _stackDropperCubeSelector.HitIndices;
            _stackDropperTester.Drop(hitIndices);
            _stackDropperCubeSelector.HitIndices.Clear();
        }
    }
}
