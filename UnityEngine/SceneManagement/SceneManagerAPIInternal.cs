// Decompiled with JetBrains decompiler
// Type: UnityEngine.SceneManagement.SceneManagerAPIInternal
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

#nullable disable
namespace UnityEngine.SceneManagement;

[NativeHeader("Runtime/Export/SceneManager/SceneManager.bindings.h")]
[NativeHeader("Runtime/SceneManager/SceneManager.h")]
[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
internal static class SceneManagerAPIInternal
{
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern int GetNumScenesInBuildSettings();

  [NativeThrows]
  public static Scene GetSceneByBuildIndex(int buildIndex)
  {
    Scene ret;
    SceneManagerAPIInternal.GetSceneByBuildIndex_Injected(buildIndex, out ret);
    return ret;
  }

  [NativeThrows]
  public static AsyncOperation LoadSceneAsyncNameIndexInternal(
    string sceneName,
    int sceneBuildIndex,
    LoadSceneParameters parameters,
    bool mustCompleteNextFrame)
  {
    return SceneManagerAPIInternal.LoadSceneAsyncNameIndexInternal_Injected(sceneName, sceneBuildIndex, ref parameters, mustCompleteNextFrame);
  }

  [NativeThrows]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern AsyncOperation UnloadSceneNameIndexInternal(
    string sceneName,
    int sceneBuildIndex,
    bool immediately,
    UnloadSceneOptions options,
    out bool outSuccess);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void GetSceneByBuildIndex_Injected(int buildIndex, out Scene ret);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern AsyncOperation LoadSceneAsyncNameIndexInternal_Injected(
    string sceneName,
    int sceneBuildIndex,
    ref LoadSceneParameters parameters,
    bool mustCompleteNextFrame);
}
