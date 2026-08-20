using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_f8dc2bac : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "f8dc2bac-b195-44c2-be78-0e259eef5ea1";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAATxJREFUSEutlDFOxFAMRIPSpImUeyDlhKlyqXCStEhsgQINUCAkQMH+a5v5jn8I2n3SCHtm/He1BdUBbkir09XwD3tdRHokQrNAh0kHEZrt6J60i5WRrus+SpkCeQgW5ORMyY+AbsYzyR7Qvwz6iPo7WUZWLM1MXdef2NcZe7LfkhJ3JInO4O5n32XUZ43j+CBzT0psjnDXPPI82CUZmzLuPkOiW0Z9UmJTwt1niN6yhmE4ib3O8/wuvrE2TfMl+fpNsKcqgZnvwX1iU2DUn6bpUSxjWZYXvPH3eksyzPR4P+rizEDH+POn8X5pZqT7RDIkyj4929u2fU2GoDnjZ1GGxL+wp/J4X2f1Sdm3Z7KDEtrzXfRFISmM0IzV9/2b2AnMSLvwPyh/kCkC8sPgkSkC8ovAhyJdjX8+XFU/Wp8B3jw2jiUAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("f8dc2bac-b195-44c2-be78-0e259eef5ea1");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_f8dc2bac() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM ChatGPT",
        nickname: "ChatGPT",
        description: @"LLM interaction with image and JSON inputs.",
        category: "ANTflow",
        subCategory: "Text Generation"
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
