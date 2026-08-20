using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_0baf619e : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "0baf619e-d7e2-43af-984f-edd2a05f0a75";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAATZJREFUSEutkzFuAkEMRbdJTRGlSUdDkyJtJIqcgt2cYC9AtBvlLtyIFmnhEBRU6RKPZe/8cTy7A+JJX9jf9p8ogmqK4bNeS3l/jn3zGzT0zY9YIzqj0qocDZGghNfnRxtak7Cf5/SVfUCDEl/23FkWfQAeGQPCH8AOYfZQEbM0Yjw8ZsHcU0QX4YAxHkvqN+1Biu0jJpCBnqUz9EIPeF5EA61oxPI8EuJ5Kfu2fcAgDPM8EuJ5Phi2q9/HQPtAqFdPi6Snz/T7jjp0Hy+8QBy7Zo8zsuaUgsfXiE6ng0vxwksk53nsMvboB4auTv6Ndp5Ag2+7hL0VH5XiHWKPn6jgzeIdYD9sN0ut0T9BfRUYEijsL9LOkwn411tPymnsYaDUK8I7yoXd9IDH3YJy0I/pLGUhVfUH7gYkqu2XAeYAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("0baf619e-d7e2-43af-984f-edd2a05f0a75");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_0baf619e() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Claude Geometry Generation",
        nickname: "Claude Geometry Generation",
        description: @"Python 3 scripting component",
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
