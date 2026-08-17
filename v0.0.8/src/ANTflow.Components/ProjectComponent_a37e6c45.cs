using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_a37e6c45 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "a37e6c45-acd7-4491-b6c5-b76d50a3ceff";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAKtJREFUSEvNjtEJwzAMRA1ZI/t1wm7QofJRaG2jg+OQm1N+0geHbEnPuP0TnwuxyWQnNlOoEI4NhGpsMtmJzRQqhGMDoRqbKVQIxwZCNTaZ7MRmChXCsYFQjU0mO7kf/oX+TO8DnZ/CyywPuIe+nk/JRMD3bE/3U/QR3F89OkPdovJ8iS6xyDPt8V6KCmDv0dmov3opWFBh1TtGo4PZswfnJbrwiMq8o95Fa19/hX6Hn7Ou4wAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("a37e6c45-acd7-4491-b6c5-b76d50a3ceff");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_a37e6c45() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "JSON Contents",
        nickname: "JSON Contents",
        description: @"Reads an already saved JSON file to output its contents. v0.1",
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
