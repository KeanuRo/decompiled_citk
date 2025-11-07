// Decompiled with JetBrains decompiler
// Type: UnityEngine.ResourcesAPI
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

using System;

#nullable disable
namespace UnityEngine;

public class ResourcesAPI
{
  private static ResourcesAPI s_DefaultAPI = new ResourcesAPI();

  internal static ResourcesAPI ActiveAPI => ResourcesAPI.overrideAPI ?? ResourcesAPI.s_DefaultAPI;

  public static ResourcesAPI overrideAPI { get; set; }

  protected internal ResourcesAPI()
  {
  }

  protected internal virtual Object[] FindObjectsOfTypeAll(Type systemTypeInstance)
  {
    return ResourcesAPIInternal.FindObjectsOfTypeAll(systemTypeInstance);
  }

  protected internal virtual Shader FindShaderByName(string name)
  {
    return ResourcesAPIInternal.FindShaderByName(name);
  }

  protected internal virtual Object Load(string path, Type systemTypeInstance)
  {
    return ResourcesAPIInternal.Load(path, systemTypeInstance);
  }

  protected internal virtual Object[] LoadAll(string path, Type systemTypeInstance)
  {
    return ResourcesAPIInternal.LoadAll(path, systemTypeInstance);
  }

  protected internal virtual ResourceRequest LoadAsync(string path, Type systemTypeInstance)
  {
    ResourceRequest resourceRequest = ResourcesAPIInternal.LoadAsyncInternal(path, systemTypeInstance);
    resourceRequest.m_Path = path;
    resourceRequest.m_Type = systemTypeInstance;
    return resourceRequest;
  }

  protected internal virtual void UnloadAsset(Object assetToUnload)
  {
    ResourcesAPIInternal.UnloadAsset(assetToUnload);
  }
}
