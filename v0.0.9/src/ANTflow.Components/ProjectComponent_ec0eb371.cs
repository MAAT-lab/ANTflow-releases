using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_ec0eb371 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "ec0eb371-edff-490e-99be-6ee8aaf97529";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAHRJREFUSEvtzDEOgDAIRuHe/2LeyFWbDgbaR/IrDA59ybcUaNv9qquYixYqjGiwmKMdcHY4cKJoF+CjE0W7AB+dKNoF+OhE0S7Ax8Uc7QRGNKjwRMOso5OiYysdfWqlo0+tT9FHCjk6VsjRsUKOjhW7t7V2A7UUlDlBX2wuAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("ec0eb371-edff-490e-99be-6ee8aaf97529");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_ec0eb371() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Webcam Snapshot",
        nickname: "Webcam Snapshot",
        description: @"Gets an image out of your webcam. v0.1",
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
