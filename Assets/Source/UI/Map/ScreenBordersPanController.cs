using Shared.Unity;
using Shared.Unity.InputControl;
using UnityEngine;

namespace StoryMapper
{
    public class ScreenBordersPanController : MonoBehaviour
    {
        public TransformTranslator2D TransformTranslator2D;

        private ScreenBordersInput screenBordersInput;

        void Awake()
        {
            screenBordersInput = GetComponent<ScreenBordersInput>();
        }

        void Update()
        {
            float x = screenBordersInput.RightValue - screenBordersInput.LeftValue;
            float y = screenBordersInput.TopValue - screenBordersInput.BottomValue;

            TransformTranslator2D.TranslateDirection = new Vector2(x, y);
        }
    }
}
