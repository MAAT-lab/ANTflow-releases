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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA8BJREFUSEutlNtTG3UUx/MX+KJvPOk4Ti8UskmIVGpGtAo6XJqKGcQitLYEI9gB1CqtktLshRSUAkoqNdimFSFtEdIKTRs6FhouljI0RYaCXEogySbpbq7LZnezLtN90AenZdjPzM7O9/zOOd/9nd/sT7QRZlUl5omCI2ZeCs+Csmjq/vsVDl4Kz2pOvndaVe7hpbBgb2eFnbn7AvcKqjCb+pSfDwuHJ2tveCZPHRgqrsUvlZ3D+LAwoNm5wbm8/dhwYfWjHo3Bf/rzq35dzYSPX94cnj3v4LOqD3z2fVVot7oZ/aHqN1R7bMx3+MSCrwjxbm5U7oLd/ukP3/PcOlC+2qU56WysNK9WHx1xq4/P+fJhL5ZTFwm8pSeDfPrGWNG86nN8kuUa+PTQQ1PF8cW6z0xLlUcHnUU1s6hSh2IZSCSUjsSiuxCa2Akza3zZ07GkTcEna9Ld1q9Vy8aaysUTWsPfmtr+BVXt1Eqmzu1LB8PBNJhcbxyTIywlg1hKCjEkX/7/OM9ujc8bE2P32uS4tTXD1d5cvKxt1C4ebDAtKvXDS2/WzbtegfFHL8NrETlEkzKYpaUQG5fCLCOBWUoCsVEAZv97+Hf+2PHX/YFEesa6jZ3p2x6ftIipWz07Q7+Ys1H4vNpVZkSc77Z2Lb/ROLaa2uD0yJEALoXIqASiKQnIxAHOQAKycTHE0mIdZwCyPs5kGgBFFgBkTopujkgeDI8AzN1hMTtuB1j7UAp19eZr0bbrSvyb3lL/gU7Yl/VzB6potaMp9fN+iR4LAjBBABAT4xox6wZc08cG6zuA4l4uNiXWMT1cDszv4zG3J1LZgfE0pnt0N2kYVEaP2UpCBy3aYE5HO674yYaltEwFpA2eIFAX4UYRI8UgQ3NfGQd0nAE3Iu6JcAZPvkp6HZmU8e7eGDi0nyy7/iWR190Uef385XDq6dGQ7NRSEKjHwmKEIJIhKiaGGWrdiHs/+ZD/za+OPUzjnUL6i8FyqrAfJDM629d2td+IyL53hIDvXMFkfSCchKxFkmGKEEM0wZdtjLbJ/Lh2tIQ5NPAVnd3bRCouXIrKztwOJbc8wHc0eLBEfQhLgonN/c3geHFcM1hBK/t0lOLiGQI4eyW03TCKbWuaQ7fWe9x82uZQ2z9mcq3VVFrPt0TSBVNwi7Hf+5LhTye/LAyZNypicos2usXcjD1v6ljhw8KhsGmiSX1H8Be6de6ErpY5PiwsL14rf5hgqZ7mpfAkWEvHnrty2MZL4Xn22kedz/xe+iMvnwKR6B8yax68VXsYRgAAAABJRU5ErkJggg==";

    public override Guid ComponentGuid { get; } = new Guid("15ee978b-df9e-4bd9-a124-536779ec9be5");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_15ee978b() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "LLM Gemini",
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
