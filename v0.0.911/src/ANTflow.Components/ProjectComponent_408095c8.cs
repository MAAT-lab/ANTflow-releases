using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_408095c8 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "408095c8-5497-4d5f-90b1-93a097dbb14f";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAQBJREFUSEutk00OgkAMhdl4ENcewXMIegEuoAH1jGxNBhKv4MKVO2VIRzv1FcqEL2nsz3sPQzQbw53yLbXL09bF25erixetvoQbjWmEEBS0yAO687wHaNpRggmF+S9Ao6qL0ETajtrIJ3URmlDuwqsbjj3yPgky8Bn1YTbDjdYiq52mLFcoCBVZ0kCBvLzmfjmot+j3zutW7TeDoKetigZptCLbDySaUxSTDgq1FNl1pJjPfO9xVQ5fI51j+sNVivgsazBZQUY+809efjcJMvDZHXfr0PN9x/pZ8BCPcX7SOI0S8DfLHbXjSKPHujOBTFpY0gMQiwVp9H+mB7VGsuwDp7E/i0iKFnUAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("408095c8-5497-4d5f-90b1-93a097dbb14f");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_408095c8() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM Claude",
        nickname: "LLM Claude",
        description: @"LLM interaction with image and JSON inputs using Anthropic Claude models. 
v0.1",
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
