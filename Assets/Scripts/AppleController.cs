using UnityEngine;

public class AppleController : MonoBehaviour
{
    [SerializeField] private SneakController _sneakController;
    // Start is called before the first frame update
    private void Start()
    {
        if( _sneakController != null )
        {
            _sneakController.OnPostionAndRotationUpdated += ComparePositions;
        }
    }
    private void ComparePositions(Vector3 postion, Quaternion rotation)
    {
        if(postion == transform.position) { SetPostion(); }
    }
    private void OnDestroy()
    {
        if (_sneakController != null)
        {
            _sneakController.OnPostionAndRotationUpdated -= ComparePositions;
        }
    }
    private void SetPostion()
    {
        System.Random rnd = new System.Random();
        var newX = (float)rnd.Next(-8, 8) + 0.5f;
        var newY = rnd.Next(-4, 4);
        transform.position = new Vector3 (newX, newY, 0);
        if(_sneakController != null)
        {
            _sneakController.AddChainOnNextStep();
        }
    }
}