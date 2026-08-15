using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_ea5ae753 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "ea5ae753-74a2-4017-a1b6-f3d97b1f0eb3";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAwRJREFUSEut0f0zFHEcB/D7C/qlfspPNU3jMbvIZDxMJkM1LkoMpagJIQnTVJTHu12kxkPDTcxN9ECMkYeEcRLjMRTHSBR5OGed9ty5287e3rd1vtP4IdPJvmZ2Zt/f3c/nu9/P8nZi0j+i8vPFu5Uwcm/6bMjYaFCcFEbuLfADFeMBMUswcos85b027xO8OhKUQEoi8lbgMnfk3ufWJs5HrHaFpiurb5SRcJkbBN9HNel3hey9lLjyJlK0IrrduJKRMqSAj3cHQD3BCURNeD5RlFBLpN7vV8RmTCtCMxW7G9XiBY+f45f9lzquxsgqo3Lmc+OrZElJvXK4JziTpVn1zNap4Os7I4tyVUij+YuSm2GzZXFpMxsNbyV2LISkTBCnUwnSE9eo3TPXtS64nnLCmV+wzDQ/UhyU0hR3ecuDgDlxcvyMIE30LTqtadr42Sx34ZrKGddRThiz7pgJaAcM0PY4o4Pl25svtTB8F1uvjzx1VLYUeS2KC0LnYM9t2WPAYI8Dxg4HtB0GtChuWIbtNn1stxkbbbPRf2m2BBONVobheoT+UOOsKq/iL8MewK+wcu5E7oAMRrapTmuH6WkYgZ0QGBAM6BEBu4GQUaA4GEeFvHr2/iGvvRed6OlFmKEeBAz2oKCr8yj99v1xDaw18n5WTrgVdRMwAhSnKJQdD4xGxg02ToAxyygGxtjNahEBkwXPsanr0zHQNujC1PR76GCdyRB2ROylYUckh+22Vyf1+nP8rRDMYLz+BjHlJ29VIfVlcgeC9bB+W7Y4TSGYnoJlO1M8HGhI7gtnwiT39Py6PJ3bi2qtQ0mX2rbgq9Lm0RJpna0mj2RSq/D1/yMcCDVEdcbpfd8JaNeqEgotbVBbifpIy/wpwiJn6d/zNkVEdyTj05JIO9c+pmxfPleZi5uWDxf2z8PH3DjZGrfu2JCuMa8qIA+UvZLBZe64tUZpbRrvKA/WCOT7Xz+ZgsvcOtQcM2tWnzgOI/fMmq/372uIlcDIvb2t1yr2NEUWw2gCHu83VgNwgamK8gQAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("ea5ae753-74a2-4017-a1b6-f3d97b1f0eb3");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_ea5ae753() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Agent Research (Gemini)",
        nickname: "Agent Research (Gemini)",
        description: @"Advanced sensory and cognitive hybrid for Grasshopper environments. It utilizes Google's Gemini Deep Research Agent to conduct extensive, long-horizon web research, capable of executing up to 160 searches for a single prompt (use carefuly as it takes time to run). It runs asynchronously. v0.1",
        category: "ANTflow",
        subCategory: "Agent"
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
