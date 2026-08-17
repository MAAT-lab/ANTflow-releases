using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_7eea62b6 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "7eea62b6-f975-4b0d-bd35-7f080155de1d";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA0VJREFUSEutlOtPUmEcgOkf6Et981OtNbNSMOuLza2tzWpewpkzyzS7YKQ5tbK0TSzwoHYxu1E6WrlqSs3KyjS1FWZXa2bKvFRmpHBED4JACueczu/1pR2ILDeeL8/7u76cA0MwF/oT9mo+JOVpcOh/vopTuj9tze7Cof8Zjkkc1SVkGnHoX6iNUZP62O0TH5NyqRbJ2TGcnhssBz7+gTEqbrI3XjLRlnrcfCfjOoXTHsw2j/hbAxkdaxmI30m9TM4fvydVjV0+9HBMXvjBhMsIbrQV2/cl7gKY4yJKchg3bzL3J2wztW/PJesk58iLuXdJ2bE3pqwTX00pytHfrwqG8PHPS3wVwYak9WO6HVuMz9Myh2ulZfryHM1wfsErg6RowJRIjFIxJbYJ6AO8Z8G/8S6AXTYr07U/aqT1wJ6h6uyiwZKD1d9yCrT6lMJ+UiwnqUilzQp9a5UuB9g9xzHPfQYj3AHfnYXrDGB1Yc7gCZnqM5z5hBNTaHFjN8uEFbNOOHvvACP4yS/qFdPgpkuRI2BZuWwQ7IswgnWBVxEsDQ4tZu1g/k7Bu2cre/Q9R+nepiDWPt7BdtYLnS6nnbmpiSahKUOt1IN9EaqgmRmzyEL5zAUigtUhK+gywdNXoX1D31XM+5dCyLHtbavR41Y+EZvBaTWECewLbhH65CL3BfgJRMVs94xpAj0FBG63doSjIZVWjJp318ssYF8IFTR6RSI5voBgbWD+ToR3Eqx+H4e+i4wnRxzxdRVokI9Q6UBfckM3zbgv8t4BRngnGYaRwLn8XbLrsDbTmfxYMRVZc/Xn2qvNtrALXVbRmRFLSOnEJPSEEM7/+pnucCf4ruxMZGSv99J7Wo+6ou9XTEXcuGMPq3phDTnfZ155ykitKLVS0Ad4z4I94BcBlORQdKQyUm22S9wgd0bcrnKIrj2wLle9poIqBshlJ40G3OaxlH/24G8FSfs+OrYp3xl+77Qj+Ea1JVD9eHSp6q0elxHc6Ox/dsBsxQ3N2dNr6mX2QM05alH1rR847cGsy/9FRIvUHtyQZ15cJzcE1J4fwGn/sqQxcyigPl+HQ/8T0JT+ZuGDrBYc+p8Fjbtq5j9Kv4LD/0Ag+AXhHWZUY0uI/wAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("7eea62b6-f975-4b0d-bd35-7f080155de1d");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_7eea62b6() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "TTS Gemini",
        nickname: "TTS Gemini",
        description: @"Generates text-to-speech audio using Google Gemini. v0.1",
        category: "ANTflow",
        subCategory: "Audio Generation"
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
