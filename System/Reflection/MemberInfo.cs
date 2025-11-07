// Decompiled with JetBrains decompiler
// Type: System.Reflection.MemberInfo
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 3020F90F-960F-4330-86D5-45C4E07AFDFD
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;

#nullable disable
namespace System.Reflection;

[ClassInterface(ClassInterfaceType.None)]
[ComDefaultInterface(typeof (_MemberInfo))]
[ComVisible(true)]
[__DynamicallyInvokable]
[Serializable]
[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
public abstract class MemberInfo : ICustomAttributeProvider, _MemberInfo
{
  internal virtual bool CacheEquals(object o) => throw new NotImplementedException();

  public abstract MemberTypes MemberType { get; }

  [__DynamicallyInvokable]
  public abstract string Name { [__DynamicallyInvokable] get; }

  [__DynamicallyInvokable]
  public abstract Type DeclaringType { [__DynamicallyInvokable] get; }

  [__DynamicallyInvokable]
  public abstract Type ReflectedType { [__DynamicallyInvokable] get; }

  [__DynamicallyInvokable]
  public virtual IEnumerable<CustomAttributeData> CustomAttributes
  {
    [__DynamicallyInvokable] get
    {
      return (IEnumerable<CustomAttributeData>) this.GetCustomAttributesData();
    }
  }

  [__DynamicallyInvokable]
  public abstract object[] GetCustomAttributes(bool inherit);

  [__DynamicallyInvokable]
  public abstract object[] GetCustomAttributes(Type attributeType, bool inherit);

  [__DynamicallyInvokable]
  public abstract bool IsDefined(Type attributeType, bool inherit);

  public virtual IList<CustomAttributeData> GetCustomAttributesData()
  {
    throw new NotImplementedException();
  }

  public virtual int MetadataToken => throw new InvalidOperationException();

  [__DynamicallyInvokable]
  public virtual Module Module
  {
    [__DynamicallyInvokable] get
    {
      if ((object) (this as Type) != null)
        return ((Type) this).Module;
      throw new NotImplementedException();
    }
  }

  [__DynamicallyInvokable]
  public static bool operator ==(MemberInfo left, MemberInfo right)
  {
    if ((object) left == (object) right)
      return true;
    if ((object) left == null || (object) right == null)
      return false;
    Type type1;
    Type type2;
    if ((type1 = left as Type) != (Type) null && (type2 = right as Type) != (Type) null)
      return type1 == type2;
    MethodBase methodBase1;
    MethodBase methodBase2;
    if ((methodBase1 = left as MethodBase) != (MethodBase) null && (methodBase2 = right as MethodBase) != (MethodBase) null)
      return methodBase1 == methodBase2;
    FieldInfo fieldInfo1;
    FieldInfo fieldInfo2;
    if ((fieldInfo1 = left as FieldInfo) != (FieldInfo) null && (fieldInfo2 = right as FieldInfo) != (FieldInfo) null)
      return fieldInfo1 == fieldInfo2;
    EventInfo eventInfo1;
    EventInfo eventInfo2;
    if ((eventInfo1 = left as EventInfo) != (EventInfo) null && (eventInfo2 = right as EventInfo) != (EventInfo) null)
      return eventInfo1 == eventInfo2;
    PropertyInfo propertyInfo1;
    PropertyInfo propertyInfo2;
    return (propertyInfo1 = left as PropertyInfo) != (PropertyInfo) null && (propertyInfo2 = right as PropertyInfo) != (PropertyInfo) null && propertyInfo1 == propertyInfo2;
  }

  [__DynamicallyInvokable]
  public static bool operator !=(MemberInfo left, MemberInfo right) => !(left == right);

  [__DynamicallyInvokable]
  public override bool Equals(object obj) => base.Equals(obj);

  [__DynamicallyInvokable]
  public override int GetHashCode() => base.GetHashCode();

  Type _MemberInfo.GetType() => this.GetType();

  void _MemberInfo.GetTypeInfoCount(out uint pcTInfo) => throw new NotImplementedException();

  void _MemberInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
  {
    throw new NotImplementedException();
  }

  void _MemberInfo.GetIDsOfNames(
    [In] ref Guid riid,
    IntPtr rgszNames,
    uint cNames,
    uint lcid,
    IntPtr rgDispId)
  {
    throw new NotImplementedException();
  }

  void _MemberInfo.Invoke(
    uint dispIdMember,
    [In] ref Guid riid,
    uint lcid,
    short wFlags,
    IntPtr pDispParams,
    IntPtr pVarResult,
    IntPtr pExcepInfo,
    IntPtr puArgErr)
  {
    throw new NotImplementedException();
  }
}
