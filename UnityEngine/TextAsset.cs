// Decompiled with JetBrains decompiler
// Type: UnityEngine.TextAsset
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58F37DBD-41B6-4D47-A3D6-9EA4D7EFAE27
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Crisis in the Kremlin Cold War\CrisisInTheKremlin2_Data\Managed\UnityEngine.CoreModule.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

#nullable disable
namespace UnityEngine;

[NativeHeader("Runtime/Scripting/TextAsset.h")]
public class TextAsset : Object
{
  public extern byte[] bytes { [MethodImpl(MethodImplOptions.InternalCall)] get; }

  [MethodImpl(MethodImplOptions.InternalCall)]
  private extern byte[] GetPreviewBytes(int maxByteCount);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private static extern void Internal_CreateInstance([Writable] TextAsset self, string text);

  [MethodImpl(MethodImplOptions.InternalCall)]
  private extern IntPtr GetDataPtr();

  [MethodImpl(MethodImplOptions.InternalCall)]
  private extern long GetDataSize();

  public string text
  {
    get
    {
      byte[] bytes = this.bytes;
      return bytes.Length == 0 ? string.Empty : TextAsset.DecodeString(bytes);
    }
  }

  public long dataSize => this.GetDataSize();

  public override string ToString() => this.text;

  public TextAsset()
    : this(TextAsset.CreateOptions.CreateNativeObject, (string) null)
  {
  }

  public TextAsset(string text)
    : this(TextAsset.CreateOptions.CreateNativeObject, text)
  {
  }

  internal TextAsset(TextAsset.CreateOptions options, string text)
  {
    if (options != TextAsset.CreateOptions.CreateNativeObject)
      return;
    TextAsset.Internal_CreateInstance(this, text);
  }

  public unsafe NativeArray<T> GetData<T>() where T : struct
  {
    long dataSize = this.GetDataSize();
    long num = (long) UnsafeUtility.SizeOf<T>();
    if (dataSize % num != 0L)
      throw new ArgumentException($"Type passed to {nameof (GetData)} can't capture the asset data. Data size is {dataSize} which is not a multiple of type size {num}");
    long length = dataSize / num;
    return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*) this.GetDataPtr(), (int) length, Allocator.None);
  }

  internal string GetPreview(int maxChars)
  {
    return TextAsset.DecodeString(this.GetPreviewBytes(maxChars * 4));
  }

  internal static string DecodeString(byte[] bytes)
  {
    int length = TextAsset.EncodingUtility.encodingLookup.Length;
    for (int index1 = 0; index1 < length; ++index1)
    {
      byte[] key = TextAsset.EncodingUtility.encodingLookup[index1].Key;
      int index2 = key.Length;
      if (bytes.Length >= index2)
      {
        for (int index3 = 0; index3 < index2; ++index3)
        {
          if ((int) key[index3] != (int) bytes[index3])
            index2 = -1;
        }
        if (index2 >= 0)
        {
          try
          {
            return TextAsset.EncodingUtility.encodingLookup[index1].Value.GetString(bytes, index2, bytes.Length - index2);
          }
          catch
          {
          }
        }
      }
    }
    int index = 0;
    return TextAsset.EncodingUtility.targetEncoding.GetString(bytes, index, bytes.Length - index);
  }

  internal enum CreateOptions
  {
    None,
    CreateNativeObject,
  }

  private static class EncodingUtility
  {
    internal static readonly KeyValuePair<byte[], Encoding>[] encodingLookup;
    internal static readonly Encoding targetEncoding = Encoding.GetEncoding(Encoding.UTF8.CodePage, (EncoderFallback) new EncoderReplacementFallback("�"), (DecoderFallback) new DecoderReplacementFallback("�"));

    static EncodingUtility()
    {
      Encoding encoding1 = (Encoding) new UTF32Encoding(true, true, true);
      Encoding encoding2 = (Encoding) new UTF32Encoding(false, true, true);
      Encoding encoding3 = (Encoding) new UnicodeEncoding(true, true, true);
      Encoding encoding4 = (Encoding) new UnicodeEncoding(false, true, true);
      Encoding encoding5 = (Encoding) new UTF8Encoding(true, true);
      TextAsset.EncodingUtility.encodingLookup = new KeyValuePair<byte[], Encoding>[5]
      {
        new KeyValuePair<byte[], Encoding>(encoding1.GetPreamble(), encoding1),
        new KeyValuePair<byte[], Encoding>(encoding2.GetPreamble(), encoding2),
        new KeyValuePair<byte[], Encoding>(encoding3.GetPreamble(), encoding3),
        new KeyValuePair<byte[], Encoding>(encoding4.GetPreamble(), encoding4),
        new KeyValuePair<byte[], Encoding>(encoding5.GetPreamble(), encoding5)
      };
    }
  }
}
