using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_8340454a : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "8340454a-cda9-49a9-a7f8-848e0bc63904";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAzBJREFUSEutldlPE1EUh/kPfNAneTIxRhalU4WglUQjgWgAi7JJAMWlZZFgNQgispROp6gYFE2KBlAwLEGDoKIFqmEvm4pAyr5IC12mdLPFLjPjtFwbfSBKmC85mXPOved3cu+ZybhthulIVsOX2MwGEFLPfPi58dGznDEQUo88NAaVRl9RgpBaVk+E/pCditN/i72ubWc/0IA0dShCzhgnItj67vNc3au0Ki1IU4My9JRhOiJRK4nP1rxOEWqEGS2awrzPKFjeGkrmSd1UVBzam5ChfMUuVT3mNKrzcgbR9MJ5NAFRb+2qlmMDNdL4SGVnYrq8LuWerORaw3L2LYmCVTCLRvPV2rAikz5IYDGA7ZtDnhKAjqaGrBAk1RzugiCjeuFqdqc8IW9axeSptUGIyXhMYDUfQexrhxDsJyj7PxbzfXUjuccVotvRS44G3FzhbHLBh/ko7rjcETtgCCxrwCUO8gnbARizgPKNkT33wOcqvK2g7i+Yd/oWAwVzK4cR/SpIOTkAE7jD6GQTOkyYIQRXA7l1hjv2S8c+etsnRJ7E5Hsv/OsbH1tHI8NQ8zJEhbxIWk4tR2RAi/Avlin9BHodCF2QwjgNJuw0HtkAxlAIwaTk8w1pd90+9tOn+iQQ9llCI4Z6IKK3x9f27tNR0xNRuC6nOUlzoR5BQ57VqoCWC4iPWSGEwJz+7waOE/AxNWnjdNjeROa54Bzr9HzxJ8TDDKxxINAi7DptzhGzjBeb8w1hNZW6gPJ2rVOZBCoymYFLimM4xCMbkFdEmgni4wogtzHNo8G2iuFwK9ydaLnSluUapn9ZvxG4Lmh8zEaDMTv5/PeQ/6RulImVDMXbb3Sl2YAWwahsMwHXhQ9iWyPFzaBsczwdicFz+1nYZfFNO9Bz4lM6qdtXrNR6Fxm13vy1rf0f4KHzeHIXx858z3O9vl5lA6ueD2dUHsWqFbBta7B7k7Gw1mwbo+m+cx57Kz6o9wgHl8AyNQSLOVa/t1znDHZV1cpBmjoC2lPM+1oynR/ZzvrSGZCmlt2itO/uTVlSEFKPeyurf0dzuhiE1LO99VLdtrfsRyD8D9zcfgFCA2RBOVrVwAAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("8340454a-cda9-49a9-a7f8-848e0bc63904");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_8340454a() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM Gemini Structured",
        nickname: "LLM Structured (Gemini)",
        description: @"LLM interaction with image and JSON inputs using Gemini for structured JSON output to be parsed later",
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
