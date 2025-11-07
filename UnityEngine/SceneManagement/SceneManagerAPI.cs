// Decompiled with JetBrains decompiler
// Type: UnityEngine.SceneManagement.SceneManagerAPI
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

#nullable disable
namespace UnityEngine.SceneManagement;

public class SceneManagerAPI
{
  private static SceneManagerAPI s_DefaultAPI = new SceneManagerAPI();

  internal static SceneManagerAPI ActiveAPI
  {
    get => SceneManagerAPI.overrideAPI ?? SceneManagerAPI.s_DefaultAPI;
  }

  public static SceneManagerAPI overrideAPI { get; set; }

  protected internal SceneManagerAPI()
  {
  }

  protected internal virtual int GetNumScenesInBuildSettings()
  {
    return SceneManagerAPIInternal.GetNumScenesInBuildSettings();
  }

  protected internal virtual Scene GetSceneByBuildIndex(int buildIndex)
  {
    return SceneManagerAPIInternal.GetSceneByBuildIndex(buildIndex);
  }

  protected internal virtual AsyncOperation LoadSceneAsyncByNameOrIndex(
    string sceneName,
    int sceneBuildIndex,
    LoadSceneParameters parameters,
    bool mustCompleteNextFrame)
  {
    return SceneManagerAPIInternal.LoadSceneAsyncNameIndexInternal(sceneName, sceneBuildIndex, parameters, mustCompleteNextFrame);
  }

  protected internal virtual AsyncOperation UnloadSceneAsyncByNameOrIndex(
    string sceneName,
    int sceneBuildIndex,
    bool immediately,
    UnloadSceneOptions options,
    out bool outSuccess)
  {
    return SceneManagerAPIInternal.UnloadSceneNameIndexInternal(sceneName, sceneBuildIndex, immediately, options, out outSuccess);
  }

  protected internal virtual AsyncOperation LoadFirstScene(bool mustLoadAsync)
  {
    return (AsyncOperation) null;
  }
}
