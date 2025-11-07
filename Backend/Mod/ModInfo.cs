// Decompiled with JetBrains decompiler
// Type: Backend.Mod.ModInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

#nullable disable
namespace Backend.Mod;

public class ModInfo
{
  public ModInfo.ModType modType;
  public string displayedName = "";
  public string id = "";
  public string description = "";
  public string version = "";

  public enum ModType
  {
    Translation,
    CSharp,
  }
}
