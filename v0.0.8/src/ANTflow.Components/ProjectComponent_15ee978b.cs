using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_15ee978b : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "15ee978b-df9e-4bd9-a124-536779ec9be5";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA0dJREFUSEutlNlP1FAUxucv8EXfeNIYI4rQAqIEJWKIoGFxDBJEUFBhcAQJ4ko0DDhtB9yB6CgKwXEFFWFAYHAgArKoSFiUICgo6yzYYbbSaTvXEm+MPhgg9Jc0zTn3nu/rOTe9osUwGJlY1hV9pgyGwjMsPvipb19aLwyFZyIsytAfmaKDobCQO0OsY+ExMz3R6aRWcmMapoVDF7LHOhAhmWmJyzY9T75PwrQw6EPDzUMR8WRbbMbPCqly+vap6ml5ZpcRLi8N3e5dpsHI/cbWmHR9uSRffzP9pV52/p0x9eKw8aDCsLRRTUUHTvcf2KtrOpQyUSq9NAYgkqwhYxRhIMNybDM7cmkz3L44xqVbjb3HQiYbjif8UKVljeScVH2H+kAs15NBCpslQOGwb1GwlC/BzcKyhfFdttHUnRkwpbkQOVqUeWLkokz5VZpdOwz1QQBmNfsR9Jyww0cBGG8cMF44R8Py/zNW4ur8VuTm6Cn0MWluBU0W58eNyq7LRo5cUY2Ic9v+dLCJmLX54CztTQDWCwdOLwJwngRgPHFgRwnw7+F/eLPhc1+DGzugWQcGatY7u9UI01Tha3lUFqqHevPiiQEnggMWkfMGGDDyJv0oJlKjGHdJ1Nju+aWtHeU+tiGgsxUFrS0bmerGbfbCerEJ1s8LL/rbYK4D3GlAcfAJkXMVKM4RsI/fvO3aDBo6/bjyjkBa2Sy2n9cmWo6oZeawx8Um/3taEuoBNMfGj8JBIxjH8l/pROW8AT8i/rHxBvNfJZW9wUzRxz0OrCWeTq4/S0WU59m2P3hhhfoAvUxaEQVFeeCMAyE4Zs6If89/yH/zpHc3d/1DLHu6OYWJrcXooKfFs1AfoNcmzR65M1Z3xazNg2AoBGcpWLY4CrujnLKORC6h4RwbWplHQ33gUfDFtOGKjnTLtZDuBLW0vxnrjHNKm9NYcY2c8X92l0JLqizrlR3kurwhvetl3RTctjQkrUe5cE0G41dxlXJ/qDKvLao1rFG+H4PLwhD8Os3ho5bZ15blkytVj8dhWjj8tVK7e80Z06py+ZRLacEQTAvL6rqUHy7qjH4YCo+LJundiqpULQyFZ3nd4afLXiXdgeECEIl+ASD3USA12J85AAAAAElFTkSuQmCC";

    public override Guid ComponentGuid { get; } = new Guid("15ee978b-df9e-4bd9-a124-536779ec9be5");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_15ee978b() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM Gemini+",
        nickname: "Gemini+",
        description: @"LLM interaction with image and JSON inputs using Gemini with various grounding and output options such as diverse file types, a json input, url, search, and map groundings, as well as structured responses. v0.2",
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
