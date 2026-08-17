using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_d7199840 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "d7199840-a488-4fc9-a0b2-8882cdfd57cc";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAMZJREFUSEvVjk0KQjEMhHsDbyFe052XdPtO4F470oFhaPqShwp+EPLTSabt1zxH/hpugF5nhz7AIxpONL+NXMaPoT+N7ETmu3DJl6NjHzWJSOkg8sM6W5HRvPHDiA2DBCWTtFgo7VQN+CnGLlWDe4/0cVA1AKWdIwYl1AC1G/osqkMo4iEGWM0A85LZImF/6THTuX6KL7I/99ADrgP6HuJHGNeRCWvN+h7iIl3UN5+pbgoFvpCZMbOeQgFFjx6+5BoQ1X9Lay9IyIGgB4t/nQAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("d7199840-a488-4fc9-a0b2-8882cdfd57cc");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_d7199840() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Data trees to JSON",
        nickname: "Data trees to JSON",
        description: @"Converts a data tree from Grasshopper into a JSON file. v0.1",
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
