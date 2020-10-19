
using UnityEngine;
namespace CheckPointSystem
{

    public class CheckPointController : MonoBehaviour
    {
        public CheckPointManager checkPointManager;
        public bool isMyTurn;
        
        [SerializeField] private CheckPointData _checkPointData;
        [SerializeField] private Material[] _checkPointMaterials;

        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (isMyTurn)
                {

                    isMyTurn = false;
                    _checkPointData.isPassed = true;
                    ChangeColor();
                    
                }
            }
           
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (_checkPointData.isPassed)
                {

                    checkPointManager.SetLastPassedCheckPoint(_checkPointData.checkPointID);
                }
            }
        }

        public void ResetCheckPoint()
        {
            _checkPointData.isPassed = false;
            ChangeColor();
        }

        private void ChangeColor()
        {
            _checkPointData.checkPointRenderer.material = _checkPointMaterials[(_checkPointData.isPassed ? 1 : 0)];

        }
    }
    [System.Serializable]
    public class CheckPointData
    {
        public int checkPointID;
        public bool isPassed;
        public Renderer checkPointRenderer;
    }

}



