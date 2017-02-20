using UnityEngine;
using System.Collections;

namespace NewtonVR.Example
{
    public class NVRExampleDegreeResult : MonoBehaviour
    {
        public NVRInteractableItem Knob;

        private TextMesh Text;

        private void Awake()
        {
            Text = this.GetComponent<TextMesh>();
        }

        private void Update()
        {
            int angle = (int)Knob.transform.localEulerAngles.y;

            if (angle == 0)
            {
                angle = 0;
            }
            else {
                angle = 360 - angle;
            }

            Text.text = angle.ToString();
        }
    }
}