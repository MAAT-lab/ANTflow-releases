using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_e63fd0a9 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "e63fd0a9-e7b4-4124-b37c-f0572cee0028";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAASBJREFUSEvtlD1KxUAUhWcVrkWwsBB5hYWgkAjCKywsLCwsLCzciZkk7sIV2L9NvLcJryfMGbkzzk8CKSz84CvmzrlnikDMX0ciV+MT6tIGznvk7UQkJyO+KFVWujOmOxUpiUi5wJHOdGcoqYhYSk/+rtugIOF4LkdWnRHVi8dQz/x8IjzbCxEtxynioon6zF6iWMlxinqZI5zZaxRH8iqmXuYIZ10rV30rktM2csPoBsaF+ryD8b2jv0XZDBn3JSm/YJ5+i6KKjE7E5csY7kRyMrIewz2KlRyvx/CAYiXH8xgesQR5TOIzuewe30DLsWN8wm9hoVz9IX4geGR8xtICuRZQfuAFizPlyi+KD3jeX0VyMlLEFx+M+eDonxrGfAOPxRKsta3JYwAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("e63fd0a9-e7b4-4124-b37c-f0572cee0028");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_e63fd0a9() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Stable Fast 3D",
        nickname: "Stable Fast 3D",
        description: @"Text to 3D model or Image to 3D model using Stability AI's Stable Fast 3D. v0.1",
        category: "ANTflow",
        subCategory: "Geometry Generation"
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
