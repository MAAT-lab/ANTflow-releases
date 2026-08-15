using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_925c9bdd : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "925c9bdd-fc86-4bfd-9b5a-76b398a4dff0";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAANJJREFUSEvVklEOwiAMhgF98dVo4gHNHriArzsPB+IgXgC7tdUaBgwcWfySP+2gtKVD7UnQoMni5wYM9+FBLqAxuf4UsNbeyK1Hc8KUsFA4Xy9PsPUcDRYQY/kSN+CcO4FthhMukdsrM3cOY6CbRGi6ofwnNXB3pcNr4yLWHvzl6RZGQK/IGNOS/A0WiTtMrVchk5TUTDCHeQQoGgv6NMLNkMnTyJhSbDNdkzPdC2SRV+whFSakXVpjm9sbxzGKAcWBS2tsc3v7FPDeh56CIn+NUi8dNGv+Yy1/sgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("925c9bdd-fc86-4bfd-9b5a-76b398a4dff0");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_925c9bdd() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Slider Actuator",
        nickname: "Slider Actuator",
        description: @"Executive (motor) that allows AI agents to physically manipulate the Grasshopper canvas. It dynamically locates target Number Sliders by their NickName and safely overrides their values",
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
