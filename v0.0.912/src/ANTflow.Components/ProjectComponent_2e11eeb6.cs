using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_2e11eeb6 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "2e11eeb6-fdca-4cf4-86b0-25c57ddb8d6b";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAOFJREFUSEvtlDEKwkAQRfcUXsbCQsRCQVBQQbCwsLCwsLCw8CZusvEWnkhP8R3wRzYxm2zWLfPgFZn8P9Ot6mjNrQ+4ZCQcPQB8ZLwdeihlT1nxR4+lWGE2Qi+pmLPmTzIBbDmuxExDDsxksSXH8UgWsrgkf8VBrzBPV4DLZIk1o+GkG1nmIePhpFtZ1CCj/2N2gEtG4mH2stiS43iYgyy25NgPc5SSyM9K8owr+1QKthx/yE7yLLSU1S/lA4Uj2VlKLWStQP2BixQ9ZeWH2gM59yvgkpFa8sUvpR4cdTSh1Bvx2dqdutQG8gAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("2e11eeb6-fdca-4cf4-86b0-25c57ddb8d6b");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_2e11eeb6() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Stable Diffusion",
        nickname: "Stable Diffusion",
        description: @"Renders viewport (or image) through a prompt, using Stability AI's Stable Diffusion services. v0.1",
        category: "ANTflow",
        subCategory: "Image Generation"
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
