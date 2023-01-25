using System;
using Compiles;
using UnityEditor;

namespace Editor.Compiles.Uses.PC
{
    public class WindowsCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;
        
        public WindowsCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.StandaloneWindows);
        }
        public WindowsCompileFactory(BuildTarget buildTarget)
        {
            if (buildTarget != BuildTarget.StandaloneWindows64)
                throw new Exception("unknown \"BuildTarget\" for windows");
            
            factory = new SimpleCompileFactory(buildTarget);
        }
        
        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = false;
            factory.Compile(path, buildOptions);
        }
    }
}