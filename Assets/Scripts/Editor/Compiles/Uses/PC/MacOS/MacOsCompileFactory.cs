using System;using Compiles;
using UnityEditor;

namespace Editor.Compiles.Uses.PC.MacOS
{
    public class MacOsCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;
        
        public MacOsCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.StandaloneOSX);
        }
        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = false;
            factory.Compile(path, buildOptions);
        }
    }
}