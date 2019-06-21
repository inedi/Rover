//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class TextBox : TextBoxBase {
  internal new static TextBox CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new TextBox(cPtr, cMemoryOwn);
  }

  internal TextBox(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(TextBox obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public TextBox() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if (type == typeof(TextBox)) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_TextBox();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public void SelectAll() {
    NoesisGUI_PINVOKE.TextBox_SelectAll(swigCPtr);
  }

  public void Select(int start, int length) {
    NoesisGUI_PINVOKE.TextBox_Select(swigCPtr, start, length);
  }

  public void Clear() {
    NoesisGUI_PINVOKE.TextBox_Clear(swigCPtr);
  }

  public int GetCharacterIndexFromPoint(Point point, bool snapToText) {
    int ret = NoesisGUI_PINVOKE.TextBox_GetCharacterIndexFromPoint(swigCPtr, ref point, snapToText);
    return ret;
  }

  public int GetCharacterIndexFromLineIndex(int lineIndex) {
    int ret = NoesisGUI_PINVOKE.TextBox_GetCharacterIndexFromLineIndex(swigCPtr, lineIndex);
    return ret;
  }

  public int GetLineIndexFromCharacterIndex(int charIndex) {
    int ret = NoesisGUI_PINVOKE.TextBox_GetLineIndexFromCharacterIndex(swigCPtr, charIndex);
    return ret;
  }

  public int GetLineLength(int lineIndex) {
    int ret = NoesisGUI_PINVOKE.TextBox_GetLineLength(swigCPtr, lineIndex);
    return ret;
  }

  public int GetFirstVisibleLineIndex() {
    int ret = NoesisGUI_PINVOKE.TextBox_GetFirstVisibleLineIndex(swigCPtr);
    return ret;
  }

  public int GetLastVisibleLineIndex() {
    int ret = NoesisGUI_PINVOKE.TextBox_GetLastVisibleLineIndex(swigCPtr);
    return ret;
  }

  public void ScrollToLine(int lineIndex) {
    NoesisGUI_PINVOKE.TextBox_ScrollToLine(swigCPtr, lineIndex);
  }

  public Rect GetRangeBounds(uint start, uint end) {
    IntPtr ret = NoesisGUI_PINVOKE.TextBox_GetRangeBounds(swigCPtr, start, end);
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Rect>(ret);
    }
    else {
      return new Rect();
    }
  }

  public void HideCaret() {
    NoesisGUI_PINVOKE.TextBox_HideCaret(swigCPtr);
  }

  public static DependencyProperty MaxLengthProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_MaxLengthProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty MaxLinesProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_MaxLinesProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty MinLinesProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_MinLinesProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TextAlignmentProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_TextAlignmentProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TextProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_TextProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TextWrappingProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_TextWrappingProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public int CaretIndex {
    set {
      NoesisGUI_PINVOKE.TextBox_CaretIndex_set(swigCPtr, value);
    } 
    get {
      int ret = NoesisGUI_PINVOKE.TextBox_CaretIndex_get(swigCPtr);
      return ret;
    } 
  }

  public int MaxLength {
    set {
      NoesisGUI_PINVOKE.TextBox_MaxLength_set(swigCPtr, value);
    } 
    get {
      int ret = NoesisGUI_PINVOKE.TextBox_MaxLength_get(swigCPtr);
      return ret;
    } 
  }

  public int MaxLines {
    set {
      NoesisGUI_PINVOKE.TextBox_MaxLines_set(swigCPtr, value);
    } 
    get {
      int ret = NoesisGUI_PINVOKE.TextBox_MaxLines_get(swigCPtr);
      return ret;
    } 
  }

  public int MinLines {
    set {
      NoesisGUI_PINVOKE.TextBox_MinLines_set(swigCPtr, value);
    } 
    get {
      int ret = NoesisGUI_PINVOKE.TextBox_MinLines_get(swigCPtr);
      return ret;
    } 
  }

  public string SelectedText {
    set {
      NoesisGUI_PINVOKE.TextBox_SelectedText_set(swigCPtr, value != null ? value : string.Empty);
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.TextBox_SelectedText_get(swigCPtr);
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public int SelectionLength {
    set {
      NoesisGUI_PINVOKE.TextBox_SelectionLength_set(swigCPtr, value);
    } 
    get {
      int ret = NoesisGUI_PINVOKE.TextBox_SelectionLength_get(swigCPtr);
      return ret;
    } 
  }

  public int SelectionStart {
    set {
      NoesisGUI_PINVOKE.TextBox_SelectionStart_set(swigCPtr, value);
    } 
    get {
      int ret = NoesisGUI_PINVOKE.TextBox_SelectionStart_get(swigCPtr);
      return ret;
    } 
  }

  public TextAlignment TextAlignment {
    set {
      NoesisGUI_PINVOKE.TextBox_TextAlignment_set(swigCPtr, (int)value);
    } 
    get {
      TextAlignment ret = (TextAlignment)NoesisGUI_PINVOKE.TextBox_TextAlignment_get(swigCPtr);
      return ret;
    } 
  }

  public string Text {
    set {
      NoesisGUI_PINVOKE.TextBox_Text_set(swigCPtr, value != null ? value : string.Empty);
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.TextBox_Text_get(swigCPtr);
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public TextWrapping TextWrapping {
    set {
      NoesisGUI_PINVOKE.TextBox_TextWrapping_set(swigCPtr, (int)value);
    } 
    get {
      TextWrapping ret = (TextWrapping)NoesisGUI_PINVOKE.TextBox_TextWrapping_get(swigCPtr);
      return ret;
    } 
  }

  public Visual TextView {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TextBox_TextView_get(swigCPtr);
      return (Visual)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.TextBox_GetStaticType();
    return ret;
  }

  internal new static IntPtr Extend(string typeName) {
    return NoesisGUI_PINVOKE.Extend_TextBox(Marshal.StringToHGlobalAnsi(typeName));
  }
}

}

