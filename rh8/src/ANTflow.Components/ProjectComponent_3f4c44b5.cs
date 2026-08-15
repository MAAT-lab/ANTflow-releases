using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_3f4c44b5 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "3f4c44b5-a2dc-4a0c-8229-63f51a659639";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAPVJREFUSEvtkTEKwkAURIP3ESy9g8QmljZ2ghax0kJIo+AJUnoVGxsLj+EB7F1XdzMbf372uwkiNj4YyM6fmSbRn69zOOkePj8jnt21EZ4lPk8ky3THDUlCtMT5o1RdYFmMN17qGM9XsIlQsVA/WagjfSNSQA9NhNrbHiLtx51Q9/ZxKvAFmgoT5QaeVaSDK1HNt7eVdDOyRcpgqofeA+ADTtLNljjiAfARmvd5NYKBJ3RIEqJ1ggFAx7gma3VGrE6WF//BCJYIHaXCWUYKc4/m+C2IrxTyjHZ73cUpDC/7tMl1P0nVlfuYaAYvV6Xbjf35IVH0AByNGc6YEPS/AAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("3f4c44b5-a2dc-4a0c-8229-63f51a659639");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_3f4c44b5() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM DeepSeek",
        nickname: "DeepSeek",
        description: @"LLM interaction with image and JSON inputs using DeepSeek models. 
v0.1",
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
