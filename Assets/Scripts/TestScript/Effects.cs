using System.Collections;
using UnityEngine;

namespace TestScript
{
    public class Effects : MonoBehaviour
    {
        public GameObject backGround;
        public SpriteRenderer backGroundRenderer;

        [SerializeField] private float correctTime = 0.25f;
        [SerializeField] private float wrongTime = 0.25f;

        private JulianTestScript m_Main;
    
        private void Awake()
        {
            m_Main = GetComponent<JulianTestScript>();
        }

        public void Correct()
        {
            //new Color(163, 255, 162);
            backGroundRenderer.color = Color.green;
            StartCoroutine(FuckingFuckerThatFuckingFuckedSoMuchFuckingFuckersItFuckingPopped(correctTime));
            //backGroundRenderer.color = Color.white;
        }

        public void Wrong()
        { 
            backGroundRenderer.color = Color.red;
                //new Color(255, 163, 162);
            StartCoroutine(FuckingFuckerThatFuckingFuckedSoMuchFuckingFuckersItFuckingPopped(wrongTime));
            //backGroundRenderer.color = Color.white;
        }

        private IEnumerator FuckingFuckerThatFuckingFuckedSoMuchFuckingFuckersItFuckingPopped(float waitTime)
        {
            print("Im a non functioning fucker");
            yield return new WaitForSeconds(waitTime);
            print("yey im workn't");
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            backGroundRenderer.color = Color.white;
            
        }
    }
}
