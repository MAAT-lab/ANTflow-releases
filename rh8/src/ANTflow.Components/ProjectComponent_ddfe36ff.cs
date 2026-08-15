using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_ddfe36ff : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "ddfe36ff-8a1e-415a-8bc0-4a3fb7fbdb12";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAr5JREFUSEut1P1LE3EYAPD9Bf1Sv/lTEaFmdjdzaG8UWVn4jg0zTSVythIRKUkMR2130xQsoyxBqKC3EWbLzNWU0uZLvqDThilKNXWv3s2XzXm7fbv0YRQyVHYfOI7nuXue53vf406wGWPiXNVAerEKQv5NJmeNDJ8t1EPIv+mENKtBnG+GkF/UqbgFY2KGYyi9iNJK7tghzR9zXMrCaKrE0ZF9k3595QkFaX5Y4hPnxlNzqM7MktlGaa394dUmu7xswAaXA2NOOk2Pic/ZdBlFlgZJjeV+0RuLrLTHVnBr0paltAa2Vab0GLvh/Bkz8iOhfNFxosI9B7dvzpT0kE1/OW4Gevl1UOlxRZPsEpRtzE9ZJD1YdtSkuSH+DX38EikRs49ATATBuqHcP+PjEO9EfdjyUJ2I1jw4uWb1x8snZvaT9CyEPhEkYoUkYoQEcuIk+v/l937e8324NcwzqglFo827vYNqjPnSGD3/TBVvgfoVx6p7pqOqjGaR0kFHEG4npFcIFciLEciDybkBCmTjhhhwhUCNK9jbgrYu4Y/OLpzt78RQnw5Huo5IpqntiLPuYzIN9T6RlRN2YQU1B6EP13R1wN8nILxWnEAjmJxtxAmWhOdY9XUgCrX2HWAbumPcte3JzlJt7jz08ItbpReXcwO4LeKORW7A+r+St/pYpr4/ZVnRkeOGPn5hJMtgCtbDndd/yf96oU9iq3szPdfa8xnotUa4cmlxL8m4MMLjgrLNqRtM88q6c9mLrdc90NNnT5WZCquYp8JJV2Bfs6Iv2yttL1wzIPTuuCWk0myC2wIj0V1iEzUlvq0Krv9g3VX7zQiX+RH7qXBZpJY5g1U11Panz6cgzZ/DWqkzvLmY3tEgNwW9ujcOaX7tbMn/FaQuMUDIvyBNXs+2dwVaCPm3teXCyy3v8x5BuAECwR/LQInHHMpk5AAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("ddfe36ff-8a1e-415a-8bc0-4a3fb7fbdb12");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_ddfe36ff() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM Gemini + Google Maps",
        nickname: "LLM Gemini + Google Maps",
        description: @"LLM interaction with image and JSON inputs using Gemini for retreiving Google Maps information. v0.1",
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
