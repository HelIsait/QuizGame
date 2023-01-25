using Compiles;
using UnityEditor;

namespace Editor.Compiles.Uses.WebGL
{
    public class WebGlCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public WebGlCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.WebGL);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = false;
            factory.Compile(path, buildOptions);
        }
    }
}