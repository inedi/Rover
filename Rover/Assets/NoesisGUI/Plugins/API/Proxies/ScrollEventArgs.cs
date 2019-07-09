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

public class ScrollEventArgs : RoutedEventArgs {
  private HandleRef swigCPtr;

  internal ScrollEventArgs(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ScrollEventArgs obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ScrollEventArgs() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_ScrollEventArgs(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  internal static new void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args) {
    ScrollEventHandler handler_ = (ScrollEventHandler)handler;
    if (handler_ != null) {
      handler_(Extend.GetProxy(sender, false), new ScrollEventArgs(args, false));
    }
  }

  public float NewValue {
    get {
      float ret = NoesisGUI_PINVOKE.ScrollEventArgs_NewValue_get(swigCPtr);
      return ret;
    } 
  }

  public ScrollEventType ScrollEventType {
    get {
      ScrollEventType ret = (ScrollEventType)NoesisGUI_PINVOKE.ScrollEventArgs_ScrollEventType_get(swigCPtr);
      return ret;
    } 
  }

  public ScrollEventArgs(object s, float value, ScrollEventType type) : this(NoesisGUI_PINVOKE.new_ScrollEventArgs(Noesis.Extend.GetInstanceHandle(s), value, (int)type), true) {
  }

}

}

