// Decompiled with JetBrains decompiler
// Type: System.OperatingSystem
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 3020F90F-960F-4330-86D5-45C4E07AFDFD
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

#nullable disable
namespace System;

[ComVisible(true)]
[Serializable]
public sealed class OperatingSystem : ICloneable, ISerializable
{
  private Version _version;
  private PlatformID _platform;
  private string _servicePack;
  private string _versionString;

  private OperatingSystem()
  {
  }

  public OperatingSystem(PlatformID platform, Version version)
    : this(platform, version, (string) null)
  {
  }

  internal OperatingSystem(PlatformID platform, Version version, string servicePack)
  {
    if (platform < PlatformID.Win32S || platform > PlatformID.MacOSX)
      throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", (object) (int) platform), nameof (platform));
    if ((object) version == null)
      throw new ArgumentNullException(nameof (version));
    this._platform = platform;
    this._version = (Version) version.Clone();
    this._servicePack = servicePack;
  }

  private OperatingSystem(SerializationInfo info, StreamingContext context)
  {
    SerializationInfoEnumerator enumerator = info.GetEnumerator();
    while (enumerator.MoveNext())
    {
      switch (enumerator.Name)
      {
        case nameof (_version):
          this._version = (Version) info.GetValue(nameof (_version), typeof (Version));
          continue;
        case nameof (_platform):
          this._platform = (PlatformID) info.GetValue(nameof (_platform), typeof (PlatformID));
          continue;
        case nameof (_servicePack):
          this._servicePack = info.GetString(nameof (_servicePack));
          continue;
        default:
          continue;
      }
    }
    if (this._version == (Version) null)
      throw new SerializationException(Environment.GetResourceString("Serialization_MissField", (object) nameof (_version)));
  }

  [SecurityCritical]
  public void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    if (info == null)
      throw new ArgumentNullException(nameof (info));
    info.AddValue("_version", (object) this._version);
    info.AddValue("_platform", (object) this._platform);
    info.AddValue("_servicePack", (object) this._servicePack);
  }

  public PlatformID Platform => this._platform;

  public string ServicePack => this._servicePack == null ? string.Empty : this._servicePack;

  public Version Version => this._version;

  public object Clone()
  {
    return (object) new OperatingSystem(this._platform, this._version, this._servicePack);
  }

  public override string ToString() => this.VersionString;

  public string VersionString
  {
    get
    {
      if (this._versionString != null)
        return this._versionString;
      string str;
      switch (this._platform)
      {
        case PlatformID.Win32S:
          str = "Microsoft Win32S ";
          break;
        case PlatformID.Win32Windows:
          str = this._version.Major > 4 || this._version.Major == 4 && this._version.Minor > 0 ? "Microsoft Windows 98 " : "Microsoft Windows 95 ";
          break;
        case PlatformID.Win32NT:
          str = "Microsoft Windows NT ";
          break;
        case PlatformID.WinCE:
          str = "Microsoft Windows CE ";
          break;
        case PlatformID.MacOSX:
          str = "Mac OS X ";
          break;
        default:
          str = "<unknown> ";
          break;
      }
      this._versionString = !string.IsNullOrEmpty(this._servicePack) ? $"{str}{this._version.ToString(3)} {this._servicePack}" : str + this._version.ToString();
      return this._versionString;
    }
  }
}
