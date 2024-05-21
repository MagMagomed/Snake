using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [Serializable]
    public abstract class Chain : MonoBehaviour
    {
        [SerializeField] public GameObject chainPref;
        public UnityAction<Vector3, Quaternion> OnPostionAndRotationUpdated { get; set; }
        public Chain NextChain { get; set; }
        protected bool _addChainOnNextStep = false;
        public void AddChainOnNextStep()
        {
            _addChainOnNextStep = true;
        }
        public void AddChain()
        {
            _addChainOnNextStep = false;
            if (NextChain != null)
            {
                NextChain.AddChain();
                return;
            }
            var newGameObject = Instantiate(chainPref, transform.position - transform.rotation * Vector2.up, transform.rotation);
            var chain = newGameObject.GetComponent<ChainController>();
            chain.PreviousChain = this;
            chain.chainPref = chainPref;
            NextChain = chain;
        }
    }
}
