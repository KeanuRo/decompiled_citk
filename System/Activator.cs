// Decompiled with JetBrains decompiler
// Type: System.Activator
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 3020F90F-960F-4330-86D5-45C4E07AFDFD
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Security;
using System.Security.Policy;
using System.Threading;

#nullable disable
namespace System;

[ClassInterface(ClassInterfaceType.None)]
[ComDefaultInterface(typeof (_Activator))]
[ComVisible(true)]
[__DynamicallyInvokable]
public sealed class Activator : _Activator
{
  internal const int LookupMask = 255 /*0xFF*/;
  internal const BindingFlags ConLookup = BindingFlags.Instance | BindingFlags.Public;
  internal const BindingFlags ConstructorDefault = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;

  private Activator()
  {
  }

  public static object CreateInstance(
    Type type,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture)
  {
    return Activator.CreateInstance(type, bindingAttr, binder, args, culture, (object[]) null);
  }

  [SecuritySafeCritical]
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static object CreateInstance(
    Type type,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes)
  {
    if ((object) type == null)
      throw new ArgumentNullException(nameof (type));
    if (type is TypeBuilder)
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_CreateInstanceWithTypeBuilder"));
    if ((bindingAttr & (BindingFlags) 255 /*0xFF*/) == BindingFlags.Default)
      bindingAttr |= BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;
    if (activationAttributes != null && activationAttributes.Length != 0)
    {
      if (!type.IsMarshalByRef)
        throw new NotSupportedException(Environment.GetResourceString("NotSupported_ActivAttrOnNonMBR"));
      if (!type.IsContextful && (activationAttributes.Length > 1 || !(activationAttributes[0] is UrlAttribute)))
        throw new NotSupportedException(Environment.GetResourceString("NotSupported_NonUrlAttrOnMBR"));
    }
    RuntimeType underlyingSystemType = type.UnderlyingSystemType as RuntimeType;
    if (underlyingSystemType == (RuntimeType) null)
      throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (type));
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return underlyingSystemType.CreateInstanceImpl(bindingAttr, binder, args, culture, activationAttributes, ref stackMark);
  }

  [__DynamicallyInvokable]
  public static object CreateInstance(Type type, params object[] args)
  {
    return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, args, (CultureInfo) null, (object[]) null);
  }

  public static object CreateInstance(Type type, object[] args, object[] activationAttributes)
  {
    return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, args, (CultureInfo) null, activationAttributes);
  }

  [__DynamicallyInvokable]
  public static object CreateInstance(Type type) => Activator.CreateInstance(type, false);

  [SecuritySafeCritical]
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static ObjectHandle CreateInstance(string assemblyName, string typeName)
  {
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return Activator.CreateInstance(assemblyName, typeName, false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, (object[]) null, (CultureInfo) null, (object[]) null, (Evidence) null, ref stackMark);
  }

  [SecuritySafeCritical]
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static ObjectHandle CreateInstance(
    string assemblyName,
    string typeName,
    object[] activationAttributes)
  {
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return Activator.CreateInstance(assemblyName, typeName, false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, (object[]) null, (CultureInfo) null, activationAttributes, (Evidence) null, ref stackMark);
  }

  [MethodImpl(MethodImplOptions.NoInlining)]
  public static object CreateInstance(Type type, bool nonPublic)
  {
    RuntimeType runtimeType = (object) type != null ? type.UnderlyingSystemType as RuntimeType : throw new ArgumentNullException(nameof (type));
    if (runtimeType == (RuntimeType) null)
      throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (type));
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return runtimeType.CreateInstanceDefaultCtor(!nonPublic, false, true, ref stackMark);
  }

  [__DynamicallyInvokable]
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static T CreateInstance<T>()
  {
    RuntimeType runtimeType = typeof (T) as RuntimeType;
    if (runtimeType.HasElementType)
      throw new MissingMethodException(Environment.GetResourceString("Arg_NoDefCTor"));
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return (T) runtimeType.CreateInstanceDefaultCtor(true, true, true, ref stackMark);
  }

  public static ObjectHandle CreateInstanceFrom(string assemblyFile, string typeName)
  {
    return Activator.CreateInstanceFrom(assemblyFile, typeName, (object[]) null);
  }

  public static ObjectHandle CreateInstanceFrom(
    string assemblyFile,
    string typeName,
    object[] activationAttributes)
  {
    return Activator.CreateInstanceFrom(assemblyFile, typeName, false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, (object[]) null, (CultureInfo) null, activationAttributes);
  }

  [SecuritySafeCritical]
  [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstance which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static ObjectHandle CreateInstance(
    string assemblyName,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes,
    Evidence securityInfo)
  {
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return Activator.CreateInstance(assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityInfo, ref stackMark);
  }

  [SecuritySafeCritical]
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static ObjectHandle CreateInstance(
    string assemblyName,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes)
  {
    StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
    return Activator.CreateInstance(assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, (Evidence) null, ref stackMark);
  }

  [SecurityCritical]
  internal static ObjectHandle CreateInstance(
    string assemblyString,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes,
    Evidence securityInfo,
    ref StackCrawlMark stackMark)
  {
    if (securityInfo != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
    Type type = (Type) null;
    Assembly assembly = (Assembly) null;
    if (assemblyString == null)
    {
      assembly = (Assembly) RuntimeAssembly.GetExecutingAssembly(ref stackMark);
    }
    else
    {
      RuntimeAssembly assemblyFromResolveEvent;
      AssemblyName assemblyName = RuntimeAssembly.CreateAssemblyName(assemblyString, false, out assemblyFromResolveEvent);
      if ((Assembly) assemblyFromResolveEvent != (Assembly) null)
        assembly = (Assembly) assemblyFromResolveEvent;
      else if (assemblyName.ContentType == AssemblyContentType.WindowsRuntime)
        type = Type.GetType($"{typeName}, {assemblyString}", true, ignoreCase);
      else
        assembly = (Assembly) RuntimeAssembly.InternalLoadAssemblyName(assemblyName, securityInfo, (RuntimeAssembly) null, ref stackMark, true, false, false);
    }
    if (type == (Type) null)
    {
      if (assembly == (Assembly) null)
        return (ObjectHandle) null;
      type = assembly.GetType(typeName, true, ignoreCase);
    }
    object instance = Activator.CreateInstance(type, bindingAttr, binder, args, culture, activationAttributes);
    return instance == null ? (ObjectHandle) null : new ObjectHandle(instance);
  }

  [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstanceFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
  public static ObjectHandle CreateInstanceFrom(
    string assemblyFile,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes,
    Evidence securityInfo)
  {
    if (securityInfo != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
    return Activator.CreateInstanceFromInternal(assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityInfo);
  }

  public static ObjectHandle CreateInstanceFrom(
    string assemblyFile,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes)
  {
    return Activator.CreateInstanceFromInternal(assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, (Evidence) null);
  }

  private static ObjectHandle CreateInstanceFromInternal(
    string assemblyFile,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes,
    Evidence securityInfo)
  {
    object instance = Activator.CreateInstance(Assembly.LoadFrom(assemblyFile, securityInfo).GetType(typeName, true, ignoreCase), bindingAttr, binder, args, culture, activationAttributes);
    return instance == null ? (ObjectHandle) null : new ObjectHandle(instance);
  }

  [SecurityCritical]
  public static ObjectHandle CreateInstance(AppDomain domain, string assemblyName, string typeName)
  {
    if (domain == null)
      throw new ArgumentNullException(nameof (domain));
    return domain.InternalCreateInstanceWithNoSecurity(assemblyName, typeName);
  }

  [SecurityCritical]
  [Obsolete("Methods which use evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstance which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
  public static ObjectHandle CreateInstance(
    AppDomain domain,
    string assemblyName,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes,
    Evidence securityAttributes)
  {
    if (domain == null)
      throw new ArgumentNullException(nameof (domain));
    if (securityAttributes != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
    return domain.InternalCreateInstanceWithNoSecurity(assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityAttributes);
  }

  [SecurityCritical]
  public static ObjectHandle CreateInstance(
    AppDomain domain,
    string assemblyName,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes)
  {
    if (domain == null)
      throw new ArgumentNullException(nameof (domain));
    return domain.InternalCreateInstanceWithNoSecurity(assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, (Evidence) null);
  }

  [SecurityCritical]
  public static ObjectHandle CreateInstanceFrom(
    AppDomain domain,
    string assemblyFile,
    string typeName)
  {
    if (domain == null)
      throw new ArgumentNullException(nameof (domain));
    return domain.InternalCreateInstanceFromWithNoSecurity(assemblyFile, typeName);
  }

  [SecurityCritical]
  [Obsolete("Methods which use Evidence to sandbox are obsolete and will be removed in a future release of the .NET Framework. Please use an overload of CreateInstanceFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
  public static ObjectHandle CreateInstanceFrom(
    AppDomain domain,
    string assemblyFile,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes,
    Evidence securityAttributes)
  {
    if (domain == null)
      throw new ArgumentNullException(nameof (domain));
    if (securityAttributes != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
    return domain.InternalCreateInstanceFromWithNoSecurity(assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityAttributes);
  }

  [SecurityCritical]
  public static ObjectHandle CreateInstanceFrom(
    AppDomain domain,
    string assemblyFile,
    string typeName,
    bool ignoreCase,
    BindingFlags bindingAttr,
    Binder binder,
    object[] args,
    CultureInfo culture,
    object[] activationAttributes)
  {
    if (domain == null)
      throw new ArgumentNullException(nameof (domain));
    return domain.InternalCreateInstanceFromWithNoSecurity(assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, (Evidence) null);
  }

  [SecuritySafeCritical]
  public static ObjectHandle CreateInstance(ActivationContext activationContext)
  {
    return (AppDomain.CurrentDomain.DomainManager ?? new AppDomainManager()).ApplicationActivator.CreateInstance(activationContext);
  }

  [SecuritySafeCritical]
  public static ObjectHandle CreateInstance(
    ActivationContext activationContext,
    string[] activationCustomData)
  {
    return (AppDomain.CurrentDomain.DomainManager ?? new AppDomainManager()).ApplicationActivator.CreateInstance(activationContext, activationCustomData);
  }

  public static ObjectHandle CreateComInstanceFrom(string assemblyName, string typeName)
  {
    return Activator.CreateComInstanceFrom(assemblyName, typeName, (byte[]) null, AssemblyHashAlgorithm.None);
  }

  public static ObjectHandle CreateComInstanceFrom(
    string assemblyName,
    string typeName,
    byte[] hashValue,
    AssemblyHashAlgorithm hashAlgorithm)
  {
    Assembly assembly = Assembly.LoadFrom(assemblyName, hashValue, hashAlgorithm);
    Type type = assembly.GetType(typeName, true, false);
    object[] customAttributes = type.GetCustomAttributes(typeof (ComVisibleAttribute), false);
    if (customAttributes.Length != 0 && !((ComVisibleAttribute) customAttributes[0]).Value)
      throw new TypeLoadException(Environment.GetResourceString("Argument_TypeMustBeVisibleFromCom"));
    if (assembly == (Assembly) null)
      return (ObjectHandle) null;
    object instance = Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, (object[]) null, (CultureInfo) null, (object[]) null);
    return instance == null ? (ObjectHandle) null : new ObjectHandle(instance);
  }

  [SecurityCritical]
  public static object GetObject(Type type, string url)
  {
    return Activator.GetObject(type, url, (object) null);
  }

  [SecurityCritical]
  public static object GetObject(Type type, string url, object state)
  {
    if (type == (Type) null)
      throw new ArgumentNullException(nameof (type));
    return RemotingServices.Connect(type, url, state);
  }

  [Conditional("_DEBUG")]
  private static void Log(bool test, string title, string success, string failure)
  {
    int num = test ? 1 : 0;
  }

  void _Activator.GetTypeInfoCount(out uint pcTInfo) => throw new NotImplementedException();

  void _Activator.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
  {
    throw new NotImplementedException();
  }

  void _Activator.GetIDsOfNames(
    [In] ref Guid riid,
    IntPtr rgszNames,
    uint cNames,
    uint lcid,
    IntPtr rgDispId)
  {
    throw new NotImplementedException();
  }

  void _Activator.Invoke(
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
