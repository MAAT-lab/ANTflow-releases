using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_f3dd4feb : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "f3dd4feb-feb3-41c2-acba-b2f41be886ee";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAwtJREFUSEutlPlPE0EUx/sX+Iv+xk8aYwCx7pZDG45oJAa1yhFCEA8gGsAGJNUYDFEpQrdYwHCIQYkYIQaEGAIVEbQQFSgeQLgkSCOgLfRk29KD0u6Ou8tIUDFCup9kMu+9mfd9O/N2l7MVphPSmoeTcpqhyz4zsckT46dFY9Bln/lTiYbJhCwddNkFPyawqaPPWkaTruKK9HITDLOHThBnm4pPt/Sm3DY/z6zDYZgd9Cejrar4VFx5LnexVVhtenCt3VSYN2yEy96hizlunk44YwR/kF0wY0wuMnh3VdqkSBPUA03CYjU0QXq+aq3gUZnLCrdvDY0w/K+nzsnv05y/Na2H7hp8KbEM0zbHnDjYPJJ3WEsn1+ZdmWVUNoASXqHnIAy4AzHCBdP/jfqJH/mtNmBltCbETCc+rkz5IS4TMwViZco5Qemsli8xLx6QLtvpWJAUeHgSQNpcAPCkwM3DgAOVgt+b//ntvi/j3QGeqS5/MNWxlxyRI+53rfwlWqC04fKCqK5UQ9snqgYXoqrmDWHFFkuYzOWgY3wZQfJlgKRtBAMepJAqIAFGqsgkKuHIUQlRzOkZ4H1VDqDEkBIBg/0o6O8Ndrf3HGIEbrZlmFIbJUwvwu/36cPKZhaRItyKYMvMOiVKINQJoO2hhgPFSAOKgQmkkGhFMUIKz7FK3/BB0D0YSrR8iKQODcANRdrSRbnYStsRjxR4ePWkhVeis6J37KsFJISHW0CQJhtlU1dEDTtV4P+/kraxKHftUBzTwMzX1530vBH7MTezhy6ESDfR5PU0jsUQjMo6jtR32wMrx5j+/AJ3ABLBPE6YtjVqRhKZ+6URtJUz10YTUDHFvGW4nSC5Uqd3X7NkMIUUvhd5HO5lRpzGZHeR/hUqvV+JTgu3eUd6/yUiuivXHdp618l9Wm/1rX1l2FP9SQ2X2SHqjWglRC52+DZX4jvrGzQwzB4RCqGD25Fj3tVSqPVpuqeCYXbZ3Zn13UeeOwld9vHpyvi440W2Arrss73zwrNtLzMeQncTcDg/AWubfVo3dbGtAAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("f3dd4feb-feb3-41c2-acba-b2f41be886ee");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_f3dd4feb() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM Gemini + url",
        nickname: "LLM Gemini + url",
        description: @"LLM interaction with image and JSON inputs using Gemini for URL searching. v0.1",
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
