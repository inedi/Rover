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

public class ScrollContentPresenter : ContentPresenter, Noesis.IScrollInfo {
  internal new static ScrollContentPresenter CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new ScrollContentPresenter(cPtr, cMemoryOwn);
  }

  internal ScrollContentPresenter(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(ScrollContentPresenter obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public ScrollContentPresenter() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_ScrollContentPresenter();
  }

  public void LineLeft() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_LineLeft(swigCPtr);
  }

  public void LineRight() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_LineRight(swigCPtr);
  }

  public void LineUp() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_LineUp(swigCPtr);
  }

  public void LineDown() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_LineDown(swigCPtr);
  }

  public void PageLeft() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_PageLeft(swigCPtr);
  }

  public void PageRight() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_PageRight(swigCPtr);
  }

  public void PageUp() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_PageUp(swigCPtr);
  }

  public void PageDown() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_PageDown(swigCPtr);
  }

  public void MouseWheelLeft(float delta) {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelLeft__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelLeft() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelLeft__SWIG_1(swigCPtr);
  }

  public void MouseWheelRight(float delta) {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelRight__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelRight() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelRight__SWIG_1(swigCPtr);
  }

  public void MouseWheelUp(float delta) {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelUp__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelUp() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelUp__SWIG_1(swigCPtr);
  }

  public void MouseWheelDown(float delta) {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelDown__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelDown() {
    NoesisGUI_PINVOKE.ScrollContentPresenter_MouseWheelDown__SWIG_1(swigCPtr);
  }

  public void SetHorizontalOffset(float offset) {
    NoesisGUI_PINVOKE.ScrollContentPresenter_SetHorizontalOffset(swigCPtr, offset);
  }

  public void SetVerticalOffset(float offset) {
    NoesisGUI_PINVOKE.ScrollContentPresenter_SetVerticalOffset(swigCPtr, offset);
  }

  public Rect MakeVisible(Visual visual, Rect rect) {
    IntPtr ret = NoesisGUI_PINVOKE.ScrollContentPresenter_MakeVisible(swigCPtr, Visual.getCPtr(visual), ref rect);
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Rect>(ret);
    }
    else {
      return new Rect();
    }
  }

  public static DependencyProperty CanContentScrollProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ScrollContentPresenter_CanContentScrollProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public bool CanContentScroll {
    set {
      NoesisGUI_PINVOKE.ScrollContentPresenter_CanContentScroll_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.ScrollContentPresenter_CanContentScroll_get(swigCPtr);
      return ret;
    } 
  }

  public bool CanHorizontallyScroll {
    set {
      NoesisGUI_PINVOKE.ScrollContentPresenter_CanHorizontallyScroll_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.ScrollContentPresenter_CanHorizontallyScroll_get(swigCPtr);
      return ret;
    } 
  }

  public bool CanVerticallyScroll {
    set {
      NoesisGUI_PINVOKE.ScrollContentPresenter_CanVerticallyScroll_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.ScrollContentPresenter_CanVerticallyScroll_get(swigCPtr);
      return ret;
    } 
  }

  public float ExtentWidth {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollContentPresenter_ExtentWidth_get(swigCPtr);
      return ret;
    } 
  }

  public float ExtentHeight {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollContentPresenter_ExtentHeight_get(swigCPtr);
      return ret;
    } 
  }

  public float ViewportWidth {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollContentPresenter_ViewportWidth_get(swigCPtr);
      return ret;
    } 
  }

  public float ViewportHeight {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollContentPresenter_ViewportHeight_get(swigCPtr);
      return ret;
    } 
  }

  public float HorizontalOffset {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollContentPresenter_HorizontalOffset_get(swigCPtr);
      return ret;
    } 
  }

  public float VerticalOffset {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollContentPresenter_VerticalOffset_get(swigCPtr);
      return ret;
    } 
  }

  public ScrollViewer ScrollOwner {
    set {
      NoesisGUI_PINVOKE.ScrollContentPresenter_ScrollOwner_set(swigCPtr, ScrollViewer.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ScrollContentPresenter_ScrollOwner_get(swigCPtr);
      return (ScrollViewer)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.ScrollContentPresenter_GetStaticType();
    return ret;
  }

}

}

