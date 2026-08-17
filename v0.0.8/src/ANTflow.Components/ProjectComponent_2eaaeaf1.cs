using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_2eaaeaf1 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "2eaaeaf1-47d9-401a-958e-ff90d1d5500f";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAMRJREFUSEu9kYENgzAMBDNtl+xIHaKNW310+TgJSJSTXtg+AxGUu3kjDt3Op3DBF4/2TEe2oAS6ErpZGplUAl0J3SyNTEbE0d7TsVs449x3rOTu5uWD/45OpzxriHsSuys/DB817N3Pek9jGFQ4cxfQzdIYBhXO3AV0szR8cPknClxe+pNvZfX23emWJ9fNDDnj3KdD9vIewTpw/21ev7LBJdWegLWIZ3WzbIkz1Z6Atchm3dAX1HsEe3cdktkC3c7fRSkfRA/6mUSKvT0AAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("2eaaeaf1-47d9-401a-958e-ff90d1d5500f");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_2eaaeaf1() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Permanent Memory",
        nickname: "Permanent Memory",
        description: @"Saves LLM conversation within a text file to be resused later",
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
