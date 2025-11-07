// Decompiled with JetBrains decompiler
// Type: UnityEngine.SceneManagement.SceneManager
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Internal;
using UnityEngine.Scripting;

#nullable disable
namespace UnityEngine.SceneManagement;

[NativeHeader("Runtime/Export/SceneManager/SceneManager.bindings.h")]
[RequiredByNativeCode]
public class SceneManager
{
  internal static bool s_AllowLoadScene = true;

  public static extern int sceneCount { [NativeMethod("GetSceneCount"), StaticAccessor("GetSceneManager()", StaticAccessorType.Dot), NativeHeader("Runtime/SceneManager/SceneManager.h"), MethodImpl(MethodImplOptions.InternalCall)] get; }

  public static extern int loadedSceneCount { [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot), NativeMethod("GetLoadedSceneCount"), NativeHeader("Runtime/SceneManager/SceneManager.h"), MethodImpl(MethodImplOptions.InternalCall)] get; }

  public static int sceneCountInBuildSettings
  {
    get => SceneManagerAPI.ActiveAPI.GetNumScenesInBuildSettings();
  }

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  internal static bool CanSetAsActiveScene(Scene scene)
  {
    return SceneManager.CanSetAsActiveScene_Injected(ref scene);
  }

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  public static Scene GetActiveScene()
  {
    Scene ret;
    SceneManager.GetActiveScene_Injected(out ret);
    return ret;
  }

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  [NativeThrows]
  public static bool SetActiveScene(Scene scene) => SceneManager.SetActiveScene_Injected(ref scene);

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  public static Scene GetSceneByPath(string scenePath)
  {
    Scene ret;
    SceneManager.GetSceneByPath_Injected(scenePath, out ret);
    return ret;
  }

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  public static Scene GetSceneByName(string name)
  {
    Scene ret;
    SceneManager.GetSceneByName_Injected(name, out ret);
    return ret;
  }

  public static Scene GetSceneByBuildIndex(int buildIndex)
  {
    return SceneManagerAPI.ActiveAPI.GetSceneByBuildIndex(buildIndex);
  }

  [NativeThrows]
  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  public static Scene GetSceneAt(int index)
  {
    Scene ret;
    SceneManager.GetSceneAt_Injected(index, out ret);
    return ret;
  }

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  [NativeThrows]
  public static Scene CreateScene([NotNull("ArgumentNullException")] string sceneName, CreateSceneParameters parameters)
  {
    Scene ret;
    SceneManager.CreateScene_Injected(sceneName, ref parameters, out ret);
    return ret;
  }

  [NativeThrows]
  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  private static bool UnloadSceneInternal(Scene scene, UnloadSceneOptions options)
  {
    return SceneManager.UnloadSceneInternal_Injected(ref scene, options);
  }

  [NativeThrows]
  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  private static AsyncOperation UnloadSceneAsyncInternal(Scene scene, UnloadSceneOptions options)
  {
    return SceneManager.UnloadSceneAsyncInternal_Injected(ref scene, options);
  }

  private static AsyncOperation LoadSceneAsyncNameIndexInternal(
    string sceneName,
    int sceneBuildIndex,
    LoadSceneParameters parameters,
    bool mustCompleteNextFrame)
  {
    return !SceneManager.s_AllowLoadScene ? (AsyncOperation) null : SceneManagerAPI.ActiveAPI.LoadSceneAsyncByNameOrIndex(sceneName, sceneBuildIndex, parameters, mustCompleteNextFrame);
  }

  private static AsyncOperation UnloadSceneNameIndexInternal(
    string sceneName,
    int sceneBuildIndex,
    bool immediately,
    UnloadSceneOptions options,
    out bool outSuccess)
  {
    if (SceneManager.s_AllowLoadScene)
      return SceneManagerAPI.ActiveAPI.UnloadSceneAsyncByNameOrIndex(sceneName, sceneBuildIndex, immediately, options, out outSuccess);
    outSuccess = false;
    return (AsyncOperation) null;
  }

  [NativeThrows]
  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  public static void MergeScenes(Scene sourceScene, Scene destinationScene)
  {
    SceneManager.MergeScenes_Injected(ref sourceScene, ref destinationScene);
  }

  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  [NativeThrows]
  public static void MoveGameObjectToScene([NotNull("ArgumentNullException")] GameObject go, Scene scene)
  {
    SceneManager.MoveGameObjectToScene_Injected(go, ref scene);
  }

  [NativeThrows]
  [StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
  private static void MoveGameObjectsToSceneByInstanceId(
    IntPtr instanceIds,
    int instanceCount,
    Scene scene)
  {
    SceneManager.MoveGameObjectsToSceneByInstanceId_Injected(instanceIds, instanceCount, ref scene);
  }

  public static unsafe void MoveGameObjectsToScene(NativeArray<int> instanceIDs, Scene scene)
  {
    if (!instanceIDs.IsCreated)
      throw new ArgumentException("NativeArray is uninitialized", nameof (instanceIDs));
    if (instanceIDs.Length == 0)
      return;
    SceneManager.MoveGameObjectsToSceneByInstanceId((IntPtr) instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, scene);
  }

  [RequiredByNativeCode]
  internal static AsyncOperation LoadFirstScene_Internal(bool async)
  {
    return SceneManagerAPI.ActiveAPI.LoadFirstScene(async);
  }

  public static event UnityAction<Scene, LoadSceneMode> sceneLoaded;

  public static event UnityAction<Scene> sceneUnloaded;

  public static event UnityAction<Scene, Scene> activeSceneChanged;

  [Obsolete("Use SceneManager.sceneCount and SceneManager.GetSceneAt(int index) to loop the all scenes instead.")]
  public static Scene[] GetAllScenes()
  {
    Scene[] allScenes = new Scene[SceneManager.sceneCount];
    for (int index = 0; index < SceneManager.sceneCount; ++index)
      allScenes[index] = SceneManager.GetSceneAt(index);
    return allScenes;
  }

  public static Scene CreateScene(string sceneName)
  {
    CreateSceneParameters parameters = new CreateSceneParameters(LocalPhysicsMode.None);
    return SceneManager.CreateScene(sceneName, parameters);
  }

  public static void LoadScene(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(mode);
    SceneManager.LoadScene(sceneName, parameters);
  }

  [ExcludeFromDocs]
  public static void LoadScene(string sceneName)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
    SceneManager.LoadScene(sceneName, parameters);
  }

  public static Scene LoadScene(string sceneName, LoadSceneParameters parameters)
  {
    SceneManager.LoadSceneAsyncNameIndexInternal(sceneName, -1, parameters, true);
    return SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
  }

  public static void LoadScene(int sceneBuildIndex, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(mode);
    SceneManager.LoadScene(sceneBuildIndex, parameters);
  }

  [ExcludeFromDocs]
  public static void LoadScene(int sceneBuildIndex)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
    SceneManager.LoadScene(sceneBuildIndex, parameters);
  }

  public static Scene LoadScene(int sceneBuildIndex, LoadSceneParameters parameters)
  {
    SceneManager.LoadSceneAsyncNameIndexInternal((string) null, sceneBuildIndex, parameters, true);
    return SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
  }

  public static AsyncOperation LoadSceneAsync(int sceneBuildIndex, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(mode);
    return SceneManager.LoadSceneAsync(sceneBuildIndex, parameters);
  }

  [ExcludeFromDocs]
  public static AsyncOperation LoadSceneAsync(int sceneBuildIndex)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
    return SceneManager.LoadSceneAsync(sceneBuildIndex, parameters);
  }

  public static AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneParameters parameters)
  {
    return SceneManager.LoadSceneAsyncNameIndexInternal((string) null, sceneBuildIndex, parameters, false);
  }

  public static AsyncOperation LoadSceneAsync(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(mode);
    return SceneManager.LoadSceneAsync(sceneName, parameters);
  }

  [ExcludeFromDocs]
  public static AsyncOperation LoadSceneAsync(string sceneName)
  {
    LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
    return SceneManager.LoadSceneAsync(sceneName, parameters);
  }

  public static AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters parameters)
  {
    return SceneManager.LoadSceneAsyncNameIndexInternal(sceneName, -1, parameters, false);
  }

  [Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
  public static bool UnloadScene(Scene scene)
  {
    return SceneManager.UnloadSceneInternal(scene, UnloadSceneOptions.None);
  }

  [Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
  public static bool UnloadScene(int sceneBuildIndex)
  {
    bool outSuccess;
    SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, true, UnloadSceneOptions.None, out outSuccess);
    return outSuccess;
  }

  [Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
  public static bool UnloadScene(string sceneName)
  {
    bool outSuccess;
    SceneManager.UnloadSceneNameIndexInternal(sceneName, -1, true, UnloadSceneOptions.None, out outSuccess);
    return outSuccess;
  }

  public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex)
  {
    return SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, false, UnloadSceneOptions.None, out bool _);
  }

  public static AsyncOperation UnloadSceneAsync(string sceneName)
  {
    return SceneManager.UnloadSceneNameIndexInternal(sceneName, -1, false, UnloadSceneOptions.None, out bool _);
  }

  public static AsyncOperation UnloadSceneAsync(Scene scene)
  {
    return SceneManager.UnloadSceneAsyncInternal(scene, UnloadSceneOptions.None);
  }

  public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex, UnloadSceneOptions options)
  {
    return SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, false, options, out bool _);
  }

  public static AsyncOperation UnloadSceneAsync(string sceneName, UnloadSceneOptions options)
  {
    return SceneManager.UnloadSceneNameIndexInternal(sceneName, -1, false, options, out bool _);
  }

  public static AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions options)
  {
    return SceneManager.UnloadSceneAsyncInternal(scene, options);
  }

  [RequiredByNativeCode]
  private static void Internal_SceneLoaded(Scene scene, LoadSceneMode mode)
  {
    if (SceneManager.sceneLoaded == null)
      return;
    SceneManager.sceneLoaded(scene, mode);
  }

  [RequiredByNativeCode]
  private static void Internal_SceneUnloaded(Scene scene)
  {
    if (SceneManager.sceneUnloaded == null)
      return;
    SceneManager.sceneUnloaded(scene);
  }

  [RequiredByNativeCode]
  private static void Internal_ActiveSceneChanged(Scene previousActiveScene, Scene newActiveScene)
  {
    if (SceneManager.activeSceneChanged == null)
      return;
    SceneManager.activeSceneChanged(previousActiveScene, newActiveScene);
  }

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern bool CanSetAsActiveScene_Injected(ref Scene scene);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void GetActiveScene_Injected(out Scene ret);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern bool SetActiveScene_Injected(ref Scene scene);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void GetSceneByPath_Injected(string scenePath, out Scene ret);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void GetSceneByName_Injected(string name, out Scene ret);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void GetSceneAt_Injected(int index, out Scene ret);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void CreateScene_Injected(
    string sceneName,
    ref CreateSceneParameters parameters,
    out Scene ret);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern bool UnloadSceneInternal_Injected(
    ref Scene scene,
    UnloadSceneOptions options);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern AsyncOperation UnloadSceneAsyncInternal_Injected(
    ref Scene scene,
    UnloadSceneOptions options);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void MergeScenes_Injected(ref Scene sourceScene, ref Scene destinationScene);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void MoveGameObjectToScene_Injected(GameObject go, ref Scene scene);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void MoveGameObjectsToSceneByInstanceId_Injected(
    IntPtr instanceIds,
    int instanceCount,
    ref Scene scene);
}
