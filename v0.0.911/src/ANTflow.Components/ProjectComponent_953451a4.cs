using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_953451a4 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "953451a4-9480-4c27-8fb8-0658612889dc";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA3tJREFUSEutlFlME0EYx/vqiy+a+MCTxhjl3EUgGLQRJQENh/VoEEVBEbCKBjVeUanadguCImJAwSIpiIBKoChQBCJHORQNViQqKkcFWopbeq3tdrsOdTcWggWkv+Sfmf8337GZSZaxEL6w48vfRZ0rp6zz+c462Pthb7KcslOQM7Q4RsIjx/vYSUqw7QCyb8oGWtwQdFuoXhGxfxJs6UazNXN05hhl6E49WObTYD4501GFRWj7d8eiYGtfPLOJo7N/o9yxXfOFvU8t239aBaytkHupS82Of6KhvZ1oZvrZGYsKmug7sEfZfChppIxzQwFCtsKEq/3qSGQcDU812L+JPXMP+MHZpJYfCx1tPHFkSJx8dSD1jHgQhG2FLJ4KDRYadIFCs5GOAdnjeMAg11fTkxI4Jr3MHhalnBq4zs39yrlW+x0c2QoD+XptAGLCNiCEmY6tFxAmsNLMPkBRuM76TeRufp/np5HmBI8W3IkZ5mZyB+IyxAOstPZBKCb/J0izFfsJLCYfhLTQ3hsh8SUr3Ky0B/rDm1ceHz80uls+SV3JTzVu1h4JhDdXbtA9Kg9TIUUJo8dFQsWunLLhrZldI/4ZCqWfcHK2x50mGCH7YD5DAvOJG4ymDu/P7R0w8bYdIrtlMClr9cWfN2025tWzNFeqEicOlSLq0IclKmaOTOWb/m3COw3VwgiGwYK/10MLEpBGWGAdhwVkL8QjKkEOAuJ/aXvnTzZ2BxAVnUGm3BaW8VJDvC5OwtWGlxRomA8aUN/s3sn1GUotnGowwojZBPEJC/hKK8wjrRC4IiADGDD1K3FMlTwEF73daea3xpqO15/HdldkGbYUPdP73+vU+dwe1MLpqB4SYpiXADdDCIFPDQKr/SPPzWP5DiLzTbTlbEsSHl3LNwWXFvzaWPDS4HNXroNvjWq90ib1nsJfBi8ExyCBBaPKFkZeT6SV2xlPHGm8YAmryjIxi58affLbdF7ZnzUeGUrUPU2HeiLYBJX+f/C7Y6yclmQLq4aHM5/kY3Bhtc4ttxN1zepXrUtXjlFpiyNBdpSIkF7EAypvYp7FYu1aUe34mtzXU78O5xHyMtnsJ+Ea15bfQVeKS35QYefBbOAYPWvOaVZV8MZcyrL7qbBzWV2XNOQiudhHWefjIk3sWl59soGyzmdZ3eHSpS8S71N2HjAYvwGs1/z26iaQNgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("953451a4-9480-4c27-8fb8-0658612889dc");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_953451a4() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Gemini Geometry",
        nickname: "Gemini Geometry",
        description: @"Generates geometry from prompts using Google Gemini. v0.1",
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
