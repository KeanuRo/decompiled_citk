// Decompiled with JetBrains decompiler
// Type: UnityEngine.ResourcesAPIInternal
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngineInternal;

#nullable disable
namespace UnityEngine;

[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
internal static class ResourcesAPIInternal
{
  [FreeFunction("Resources_Bindings::FindObjectsOfTypeAll")]
  [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern Object[] FindObjectsOfTypeAll(Type type);

  [FreeFunction("GetShaderNameRegistry().FindShader")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern Shader FindShaderByName(string name);

  [FreeFunction("Resources_Bindings::Load")]
  [NativeThrows]
  [TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern Object Load(string path, [NotNull("ArgumentNullException")] Type systemTypeInstance);

  [NativeThrows]
  [FreeFunction("Resources_Bindings::LoadAll")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern Object[] LoadAll([NotNull("ArgumentNullException")] string path, [NotNull("ArgumentNullException")] Type systemTypeInstance);

  [FreeFunction("Resources_Bindings::LoadAsyncInternal")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  internal static extern ResourceRequest LoadAsyncInternal(string path, Type type);

  [FreeFunction("Scripting::UnloadAssetFromScripting")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern void UnloadAsset(Object assetToUnload);

  internal static class EntitiesAssetGC
  {
    internal static ResourcesAPIInternal.EntitiesAssetGC.AdditionalRootsHandlerDelegate AdditionalRootsHandler;

    [FreeFunction("Resources_Bindings::MarkInstanceIDsAsRoot")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void MarkInstanceIDsAsRoot(IntPtr instanceIDs, int count, IntPtr state);

    [FreeFunction("Resources_Bindings::EnableEntitiesAssetGCCallback")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void EnableEntitiesAssetGCCallback();

    internal static void RegisterAdditionalRootsHandler(
      ResourcesAPIInternal.EntitiesAssetGC.AdditionalRootsHandlerDelegate newAdditionalRootsHandler)
    {
      if (ResourcesAPIInternal.EntitiesAssetGC.AdditionalRootsHandler == null)
      {
        ResourcesAPIInternal.EntitiesAssetGC.EnableEntitiesAssetGCCallback();
        ResourcesAPIInternal.EntitiesAssetGC.AdditionalRootsHandler = newAdditionalRootsHandler;
      }
      else
        Debug.LogWarning((object) "Attempting to register more than one AdditionalRootsHandlerDelegate! Only one may be registered at a time.");
    }

    [UsedByNativeCode]
    private static void GetAdditionalRoots(IntPtr state)
    {
      if (ResourcesAPIInternal.EntitiesAssetGC.AdditionalRootsHandler == null)
        return;
      ResourcesAPIInternal.EntitiesAssetGC.AdditionalRootsHandler(state);
    }

    internal delegate void AdditionalRootsHandlerDelegate(IntPtr state);
  }
}
