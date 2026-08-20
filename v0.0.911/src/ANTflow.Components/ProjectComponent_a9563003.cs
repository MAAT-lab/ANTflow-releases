using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_a9563003 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "a9563003-18ba-4079-9499-7d968597b03b";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAM9JREFUSEvtktsNwyAMRYF8d4t0nn5UVefhkyU6FWKDzEF52AKFhzBNVFXqka5wLHydOGbfxGY6BinlDUJPNOepgVLqAuEMHM2SMT5n8XpdN3fSWYQIBhwbBLmmEGP+eX+83DkNGtXAZnMEYzeGRYS3LuAxj6Mik+bdB++Qm4wWjt6rEgtbI4Av5JMjQmKTqJxWnkRuAkprutM0VuC2eKUfH+MPx7MHzOtr++dQYNanqZpsigLUlCY9UYCa0qQnY4zVWg8p1PiCM+Wa/DSMvQH0LmokcuddDAAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("a9563003-18ba-4079-9499-7d968597b03b");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_a9563003() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Toggle Actuator",
        nickname: "Toggle Actuator",
        description: @"Executive (motor) that allows AI agents to physically manipulate the Grasshopper canvas. It dynamically locates target Number Sliders by their NickName and safely overrides their values. v0.1",
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
