// Decompiled with JetBrains decompiler
// Type: UnityEngine.Resources
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngineInternal;

#nullable disable
namespace UnityEngine;

[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
public sealed class Resources
{
  internal static T[] ConvertObjects<T>(Object[] rawObjects) where T : Object
  {
    if (rawObjects == null)
      return (T[]) null;
    T[] objArray = new T[rawObjects.Length];
    for (int index = 0; index < objArray.Length; ++index)
      objArray[index] = (T) rawObjects[index];
    return objArray;
  }

  public static Object[] FindObjectsOfTypeAll(Type type)
  {
    return ResourcesAPI.ActiveAPI.FindObjectsOfTypeAll(type);
  }

  public static T[] FindObjectsOfTypeAll<T>() where T : Object
  {
    return Resources.ConvertObjects<T>(Resources.FindObjectsOfTypeAll(typeof (T)));
  }

  public static Object Load(string path) => Resources.Load(path, typeof (Object));

  public static T Load<T>(string path) where T : Object => (T) Resources.Load(path, typeof (T));

  public static Object Load(string path, Type systemTypeInstance)
  {
    return ResourcesAPI.ActiveAPI.Load(path, systemTypeInstance);
  }

  public static ResourceRequest LoadAsync(string path)
  {
    return Resources.LoadAsync(path, typeof (Object));
  }

  public static ResourceRequest LoadAsync<T>(string path) where T : Object
  {
    return Resources.LoadAsync(path, typeof (T));
  }

  public static ResourceRequest LoadAsync(string path, Type type)
  {
    return ResourcesAPI.ActiveAPI.LoadAsync(path, type);
  }

  public static Object[] LoadAll(string path, Type systemTypeInstance)
  {
    return ResourcesAPI.ActiveAPI.LoadAll(path, systemTypeInstance);
  }

  public static Object[] LoadAll(string path) => Resources.LoadAll(path, typeof (Object));

  public static T[] LoadAll<T>(string path) where T : Object
  {
    return Resources.ConvertObjects<T>(Resources.LoadAll(path, typeof (T)));
  }

  [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
  [FreeFunction("GetScriptingBuiltinResource", ThrowsException = true)]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern Object GetBuiltinResource([NotNull("ArgumentNullException")] Type type, string path);

  public static T GetBuiltinResource<T>(string path) where T : Object
  {
    return (T) Resources.GetBuiltinResource(typeof (T), path);
  }

  public static void UnloadAsset(Object assetToUnload)
  {
    ResourcesAPI.ActiveAPI.UnloadAsset(assetToUnload);
  }

  [FreeFunction("Scripting::UnloadAssetFromScripting")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void UnloadAssetImplResourceManager(Object assetToUnload);

  [FreeFunction("Resources_Bindings::UnloadUnusedAssets")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern AsyncOperation UnloadUnusedAssets();

  [FreeFunction("Resources_Bindings::InstanceIDToObject")]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern Object InstanceIDToObject(int instanceID);

  [FreeFunction("Resources_Bindings::InstanceIDToObjectList", IsThreadSafe = true)]
  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void InstanceIDToObjectList(
    IntPtr instanceIDs,
    int instanceCount,
    List<Object> objects);

  public static unsafe void InstanceIDToObjectList(
    NativeArray<int> instanceIDs,
    List<Object> objects)
  {
    if (!instanceIDs.IsCreated)
      throw new ArgumentException("NativeArray is uninitialized", nameof (instanceIDs));
    if (objects == null)
      throw new ArgumentNullException(nameof (objects));
    if (instanceIDs.Length == 0)
      objects.Clear();
    else
      Resources.InstanceIDToObjectList((IntPtr) instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, objects);
  }

  [FreeFunction("Resources_Bindings::InstanceIDsToValidArray", IsThreadSafe = true)]
  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void InstanceIDsToValidArray_Internal(
    IntPtr instanceIDs,
    int instanceCount,
    IntPtr validArray,
    int validArrayCount);

  [FreeFunction("Resources_Bindings::DoesObjectWithInstanceIDExist", IsThreadSafe = true)]
  [MethodImpl(MethodImplOptions.InternalCall)]
  public static extern bool InstanceIDIsValid(int instanceId);

  public static unsafe void InstanceIDsToValidArray(
    NativeArray<int> instanceIDs,
    NativeArray<bool> validArray)
  {
    if (!instanceIDs.IsCreated)
      throw new ArgumentException("NativeArray is uninitialized", nameof (instanceIDs));
    if (!validArray.IsCreated)
      throw new ArgumentException("NativeArray is uninitialized", nameof (validArray));
    if (instanceIDs.Length != validArray.Length)
      throw new ArgumentException("Size mismatch! Both arrays must be the same length.");
    if (instanceIDs.Length == 0)
      return;
    Resources.InstanceIDsToValidArray_Internal((IntPtr) instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, (IntPtr) validArray.GetUnsafePtr<bool>(), validArray.Length);
  }

  public static unsafe void InstanceIDsToValidArray(
    ReadOnlySpan<int> instanceIDs,
    Span<bool> validArray)
  {
    if (instanceIDs.Length != validArray.Length)
      throw new ArgumentException("Size mismatch! Both arrays must be the same length.");
    if (instanceIDs.Length == 0)
      return;
    fixed (int* instanceIDs1 = &instanceIDs.GetPinnableReference())
      fixed (bool* validArray1 = &validArray.GetPinnableReference())
        Resources.InstanceIDsToValidArray_Internal((IntPtr) (void*) instanceIDs1, instanceIDs.Length, (IntPtr) (void*) validArray1, validArray.Length);
  }
}
