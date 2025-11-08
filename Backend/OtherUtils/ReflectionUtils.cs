// Decompiled with JetBrains decompiler
// Type: Backend.OtherUtils.ReflectionUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1AEE2D60-F9AC-4BB1-9F59-FC7C8812BBA8
// Assembly location: C:\Users\Киану\RiderProjects\SampleCitK2Mod\lib\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace Backend.OtherUtils;

public static class ReflectionUtils
{
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static IEnumerable<Type> GetTypesByAttributes(Type T)
  {
    return ((IEnumerable<Type>) Assembly.GetAssembly(typeof (ReflectionUtils)).GetTypes()).Where<Type>((Func<Type, bool>) (t => t.IsDefined(T)));
  }
}
