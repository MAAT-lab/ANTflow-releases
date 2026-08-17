using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_d9b4d4d8 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "d9b4d4d8-9ee6-494c-a721-99dacda4c4f9";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAANpJREFUSEvNj9ENAjEMQyuxDCOwBHsxByvAB3PwzyYgSHQ1MiZpiw5xPClK69jpXelwr/3r+GIs5/NsWstmP+ThzXRswg/tau+CEIIZkW8kNxRw7TQd03mKDg9W0LzrPFuW6R8HFnvACWc/eSAaRNrNKnsAe1BvuOgLgJrSYOVi1fO8GLg3Q8So77l0OPCX8NfrH+nd0XkXNnPYYQ26nrtEQcD3yKf+EF2C+95KZ+ir2nmeoiYO8kw19oVoAKytdOa9pYXAoIFMu7pgYHa0wjlFDdvamXPtS1HKA0T+jhmNSdUOAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("d9b4d4d8-9ee6-494c-a721-99dacda4c4f9");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_d9b4d4d8() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Rhino Model to JSON",
        nickname: "Rhino Model to JSON",
        description: @"Extract Rhino model and geometry information inito a JSON file. v0.2",
        category: "ANTflow",
        subCategory: "Utilities"
        )
    {
    }

    protected override void AppendAdditionalComponentMenuItems(SWF.ToolStripDropDown menu)
    {
      base.AppendAdditionalComponentMenuItems(menu);
      if (m_script is null) return;
      m_script.AppendAdditionalMenuItems(this, menu);
    }

    protected override void RegisterInputParams(GH_InputParamManager _) { }

    protected override void RegisterOutputParams(GH_OutputParamManager _) { }

    protected override void BeforeSolveInstance()
    {
      if (m_script is null) return;
      m_script.BeforeSolve(this);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
      if (m_script is null) return;
      m_script.Solve(this, DA);
    }

    protected override void AfterSolveInstance()
    {
      if (m_script is null) return;
      m_script.AfterSolve(this);
    }

    public override void RemovedFromDocument(GH_Document document)
    {
      ProjectComponentPlugin.DisposeScript(this, m_script);
      base.RemovedFromDocument(document);
    }

    public override BoundingBox ClippingBox
    {
      get
      {
        if (m_script is null) return BoundingBox.Empty;
        return m_script.GetClipBox(this);
      }
    }

    public override void DrawViewportWires(IGH_PreviewArgs args)
    {
      if (m_script is null) return;
      m_script.DrawWires(this, args);
    }

    public override void DrawViewportMeshes(IGH_PreviewArgs args)
    {
      if (m_script is null) return;
      m_script.DrawMeshes(this, args);
    }
  }
}
