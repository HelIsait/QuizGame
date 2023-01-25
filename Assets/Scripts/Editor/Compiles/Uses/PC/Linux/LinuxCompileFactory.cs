using Compiles;
using UnityEditor;

namespace Editor.Compiles.Uses.PC.Linux
{
    public class LinuxCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public LinuxCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.StandaloneLinux64);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = false;
            factory.Compile(path, buildOptions);
        }
    }
}