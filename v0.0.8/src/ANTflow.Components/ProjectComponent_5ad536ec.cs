using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_5ad536ec : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "5ad536ec-3676-4a81-9a09-a13a1dc57657";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAOFJREFUSEvdjTEKAkEMRbf0IF5HRfAIdotYWdtZbWnvvaz1EuLs6AwJxG/GZMcFwQefTSb//21+RRQaFSzGvRqryLqbcPiSN52vf3CnL5bwm3ZzI4NYiLcqtKD3zcV//IDF4Iz3KmQR6oVZ28ckWvNOowtZvOIyVDIypTcaVfKRgyVl5xPtlkRnHS2giexvfnouk0zLbThjUNOu69c8U9xGM3OJLNPeXJTMWiHuLj4FZKEUnX1YIVlseYtgMM37U5yk+XCMU75Lz2CwQO7zNtx4l57ByBIUWcZjsQlXGg2a5gGk52Y6L7HkVgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("5ad536ec-3676-4a81-9a09-a13a1dc57657");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_5ad536ec() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "DeepSeek Geometry",
        nickname: "DeepSeek Geometry",
        description: @"Generates geometry from prompts using Google Gemini. v0.2",
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
