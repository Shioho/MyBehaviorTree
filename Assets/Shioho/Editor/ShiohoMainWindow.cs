using UnityEditor;

namespace Shioho
{
    public class ShiohoMainWindow : EditorWindow
    {
        [MenuItem("Shioho/ShiohoWindow %t")]
        static void OpenWindow()
        {
            var window = GetWindow<ShiohoMainWindow>(true, "ShiohoWindow");
            window.Show();
        }


    }
}