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

public class GridView : ViewBase {
  internal new static GridView CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new GridView(cPtr, cMemoryOwn);
  }

  internal GridView(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(GridView obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public GridView() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_GridView();
  }

  public static GridViewColumnCollection GetColumnCollection(DependencyObject element) {
    if (element == null) throw new ArgumentNullException("element");
    {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_GetColumnCollection(DependencyObject.getCPtr(element));
      return (GridViewColumnCollection)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static void SetColumnCollection(DependencyObject element, GridViewColumnCollection value) {
    if (element == null) throw new ArgumentNullException("element");
    {
      NoesisGUI_PINVOKE.GridView_SetColumnCollection(DependencyObject.getCPtr(element), GridViewColumnCollection.getCPtr(value));
    }
  }

  public static DependencyProperty AllowsColumnReorderProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_AllowsColumnReorderProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnHeaderContainerStyleProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderContainerStyleProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnHeaderContextMenuProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderContextMenuProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnHeaderStringFormatProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderStringFormatProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnHeaderTemplateProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderTemplateProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnHeaderTemplateSelectorProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderTemplateSelectorProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnHeaderToolTipProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderToolTipProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ColumnCollectionProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnCollectionProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public bool AllowsColumnReorder {
    set {
      NoesisGUI_PINVOKE.GridView_AllowsColumnReorder_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.GridView_AllowsColumnReorder_get(swigCPtr);
      return ret;
    } 
  }

  public Style ColumnHeaderContainerStyle {
    set {
      NoesisGUI_PINVOKE.GridView_ColumnHeaderContainerStyle_set(swigCPtr, Style.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderContainerStyle_get(swigCPtr);
      return (Style)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public ContextMenu ColumnHeaderContextMenu {
    set {
      NoesisGUI_PINVOKE.GridView_ColumnHeaderContextMenu_set(swigCPtr, ContextMenu.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderContextMenu_get(swigCPtr);
      return (ContextMenu)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public string ColumnHeaderStringFormat {
    set {
      NoesisGUI_PINVOKE.GridView_ColumnHeaderStringFormat_set(swigCPtr, value != null ? value : string.Empty);
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderStringFormat_get(swigCPtr);
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public DataTemplate ColumnHeaderTemplate {
    set {
      NoesisGUI_PINVOKE.GridView_ColumnHeaderTemplate_set(swigCPtr, DataTemplate.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderTemplate_get(swigCPtr);
      return (DataTemplate)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public DataTemplateSelector ColumnHeaderTemplateSelector {
    set {
      NoesisGUI_PINVOKE.GridView_ColumnHeaderTemplateSelector_set(swigCPtr, DataTemplateSelector.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderTemplateSelector_get(swigCPtr);
      return (DataTemplateSelector)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public object ColumnHeaderToolTip {
    set {
      NoesisGUI_PINVOKE.GridView_ColumnHeaderToolTip_set(swigCPtr, Noesis.Extend.GetInstanceHandle(value));
    }
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_ColumnHeaderToolTip_get(swigCPtr);
      return Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public GridViewColumnCollection Columns {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridView_Columns_get(swigCPtr);
      return (GridViewColumnCollection)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.GridView_GetStaticType();
    return ret;
  }

}

}

