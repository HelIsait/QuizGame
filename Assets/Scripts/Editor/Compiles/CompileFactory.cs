#nullable enable
using Editor.Compiles.Uses;
using Editor.Compiles.Uses.PC;
using Editor.Compiles.Uses.PC.Linux;
using Editor.Compiles.Uses.PC.MacOS;
using Editor.Compiles.Uses.WebGL;
using Uitls;
using UnityEditor;
using UnityEngine;


namespace Compiles
{
    public class CompileFactory : MonoBehaviour
    {
        [SerializeField] private string path = string.Empty;


        //[Menu(nameof(Compile))]
        [MenuItem("CompileFactory/Compile")]
        public static void Compile()
        {
            new ManyCompileFactory(
                new ExtensionWhenFolderCompileFactory(
                    new ApkCompileFactory(),
                    ".apk"
                ),
                new ExtensionWhenFolderCompileFactory(
                    new AabCompileFactory(),
                    ".aab"
                ),
                new ExtensionWhenFolderCompileFactory(
                    new SimpleCompileFactory(BuildTarget.StandaloneOSX),
                    ".app"
                ),
                new ExtensionWhenFolderCompileFactory(
                    new WindowsCompileFactory(),
                    ".exe"
                    ),
                new ExtensionWhenFolderCompileFactory(
                    new WindowsCompileFactory(BuildTarget.StandaloneWindows64),
                    ".exe"
                    ),
                new ExtensionWhenFolderCompileFactory(
                    new MacOsCompileFactory(),
                    ".dmg"
                    ),
                new ExtensionWhenFolderCompileFactory(
                    new LinuxCompileFactory(),
                    ".exe"
                    ),
                new ExtensionWhenFolderCompileFactory(
                    new WebGlCompileFactory(),
                    ".gltf")
                )
                
                .Compile(
                EditorUtility.OpenFolderPanel(
                    "Choose folder",
                    "Assets",
                    "build"
                ).EnsureNotNull(),
                BuildOptions()
            );
        }


        private static BuildOptions BuildOptions()
        {
            return GetCurrentBuildOptions().options;
        }


        private static BuildPlayerOptions GetCurrentBuildOptions(BuildPlayerOptions defaultOptions = new())
        {
            return BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(defaultOptions);
        }
    }
}