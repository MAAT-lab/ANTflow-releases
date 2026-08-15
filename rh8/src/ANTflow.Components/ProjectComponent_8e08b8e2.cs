using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_8e08b8e2 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "8e08b8e2-6b9f-45b5-913c-ef620461250d";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAuFJREFUSEutlM1P03AcxhdPHjy6izFEFIj4wrsEh24ykJgo8YSRRGNiULKhMR48eDHEgweMiRESOKlH4z/gReRliCJgjFNgDAQGtGOBre22vmyFx1/rOttuAgKf5Em//fb3fZ7ut7aW3cRuz9n75mVHc+rUAEzaiFdEWdd2NFlx/1J51vlsTb2JJjOG3ovGfei6tj/bOsNCzWwjaehrSzzU9ZrtKzD0NMxDaSnoz61Wq3LU0Ncqkb78jJ6CeUiVHpfLle4TaehrFdazxQC3252y/ot2TVmUQl9bpLkr4AaPG3oa5iFVemw2W7pPpKGvLYmlG+BHy8AMnDD0FcxDaSmYe0Qa6VqiH2CNaoHoPYPYSOajah7aTBrpem3ZDelnHRITtYiNVSI8YNwq/bDhQhYyXjRu8bGYpFuQGD8PcfwcYqNVWP1wbDOfrZOkXMDSTSQn6iGNOxEfrsBKT+HuBMQDbVhbbFa3RwkQvHbyJxft3i8QBAHxOIdo4C2kyXqyPZWqOdNTsvMAURLACQmwUQ5cLArJWwtmsGjn2yPL8kP+6mVoUszDLAMqGFLvfkcBosirpqtNF9U7j3Asuj0UglwIs/ML29t7Weq9LgfdEAQeHM+oAeEoC4YEOLoTqO4UUfU8hpnZOYT7izMD+MAtyEEXEtRtyPRdJIP3sE67yLFV7cvBO+TxcyA20AqW4yEOHQTDMFhlIqBXQqh4JqC6PaIGpCyNiMOFEMfKIX07hYTXRszs5I10QPLVEDmRnHRC9tWRz4BdNRU8B1Df2YjAAoWzbRfgeNrwb3MFti8XiqJDR8F/OQnpaxkJK0fSexrijyoiG8TvleBHirFE05hfXEBNewOcT/5oyv9r831n+wsQfp+DSE8umN5D4Dx5iA7mk8euIKXD4Prz4Jv2Y3JqGhM+v6qp6S2Ya+DR+h4liO3NJ0FHMqT0ff6ZtFJj24f7XIjYx1KiEsQ/lYLyvvtPU4vlNy+unXWnpDmKAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("8e08b8e2-6b9f-45b5-913c-ef620461250d");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_8e08b8e2() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Render Viewport (Nano Banana)",
        nickname: "Render Viewport (Nano Banana)",
        description: @"Renders viewport (or image) through a prompt, using Nano Banana",
        category: "ANTflow",
        subCategory: "Image Generation"
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
