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
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAA1tJREFUSEutldlPE1EUxvkPfNAnfdIYg4rQqSJqqXEhoAawKG5EcA0E1Gg1RIMGtHRmiruiYdQIihuIiiCyoxEEiogL0FRBiiCFLtN2Ou20dJm5DvHa+GICYX7Jzcw5597vm3vuTSZoKvRvSy37nHSyDIbCM5iwR9OzS94LQ+HRx+0ktTsOG2EoLNaNcc6Rzbvt3UknbI1p1ywwLRyG2K2Ob4lp9vd7FdTzI8U2mBYGY9xmuj9xn02dnGV5mUFYiMxqS27OJxKWp4dRtonq276bbEvJNAJIzplO8mjuIJmCm6fXqtGkKIs2eVtA+OrxstGs02oDDEF8HmOPVnloOH1q6DOkJNQBD+SKn6rMBz+PZTXrU3L6TTKl2RaNMw5YBitxdhwumxxDZ8Opr9nrA1+qyCYG0s/VDm5XaPQblEZyLeqkJSqPG5bBMgz4lqKsBy7/PyP3F3K6whBv950IqrYgxmAyDHigBpCdbx+KUunGVuF2awQ+zsA0uNUMwFIUcGLeRIwCF4JzZij3h653odreNyH+b3WLwPeaxdyXV2G+d+US+vGzWNOoWec5dBcf2Vrw9BfUCyDG/LwgyxEt/DtvIEKBX6TkDVCWRHBWyz9f8eNC0JsOcV+7GmE/qUXgYysC2lrDfa/frmFu1yVQQ1adb38pTsbee2JaXdBqWnZRZ5FcoWgEc7kRjPUiOGAnDJC/BhM7wFgzPzRi1F/B5xVwH39o/bwCNHVJ2PIPUR6iZYtriBrwH6g8S8c/LqKkdxtt4fkaKvKaiUbyGL4VXo8IZf1EMwcQJW/At4gfDIJxBij3fyp7YnyFXQneYXsfd7jhlDux/Dqz7uELZwTR4ZDeHKZFF6yMSOV2h2E+L38G7ISRCJvEIf9LSY+Mhe0GyTWYJ6a0aHxVYQMTSWicyJUxOuy83QnLgBd3wWVT487XnVx2R2rASPrwuUtS1B64/yF5DlsI5p7e/wH9uJdLb5H7ZTVKL9QFi299sC66/sO08JJpDE6bHmlt6Wx8fZZPUnHZHfqomA4urDUvIDp/wbIwxDTJvcurFEzw03zb3OInepgWDmljhmtJ9Ulq3kulYXZp/g+YFpb5dUeG51Sc0sJQeObUp3bMqjzaBEPhmVl/sGRGVdoNGE6CoKDfcotU8xVmHe8AAAAASUVORK5CYII=";

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
