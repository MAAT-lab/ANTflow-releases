using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_33e6874d : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "33e6874d-4642-4a91-8002-69a8a4410fe7";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAOlJREFUSEu9josNwyAMROkOXauDdahskl0oEBv5c2BIqz7pBNh3NonIdP6aB51twcqSVV9F+XLOYbh5yBfhfRw+T7ioD6fgaEnrjTyjIaou+hbbny9gk62xaq+lLqJ+w5kizTLXSAMy3hWNdKhf8RvV0FueRY4nMHVFNZB1IFO7s+Qb+UzNoUw2jHr2NHeNDco312TP1qyvSOGCUlxDPnnaflGnG6pkYKUmh/Kd30W1OjVMa+hOng4XuuEb0ZwpMFhVe0Vv5KHeEi48GBD1h6hgEF7xOHZD0r/E9o8K+Tg2FpDu8KLzX6T0AWHe2WQpz1lvAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("33e6874d-4642-4a91-8002-69a8a4410fe7");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_33e6874d() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "JSON explode",
        nickname: "JSON explode",
        description: @"Explodes a JSON file into data trees for Keys and Values. Records-to-branches DataTree (immediate keys + values). v0.1",
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
