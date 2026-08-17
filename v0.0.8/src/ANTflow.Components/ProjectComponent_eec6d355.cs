using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_eec6d355 : ProjectComponent_Base
  {
    static readonly string s_scriptDataId = "eec6d355-6056-41b0-b66a-0291ee4ba68b";
    static readonly string s_scriptIconData = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAAnRJREFUSEu1lM9P02AcxoknDx71YgwRBeL8wa8hmaCbDFxMlHjCSKIxMSgZaIwHD14M8eABY2KEBE7Go/Ef8OLc2CaKgDFWgTEQGKOdC9vad11/rePxbR0mhhgVuid50rxv0ufz9um3LbNSTmf5zhfPBruLS+s12LUHd87bUVxar6eduzB8eXfpALnk8HMhUF06gKFMoKq0ACFUQoC6dBEkfKR0AG31KqTJBvDBo9ZDVO4uCmwPFOYkxIkSjGrhey/Ur+3QZtogTjUhHbSwKhJ/oOS5HmjTZ6BMn4Y46UDqzWHrAHnWC6xeQ37GA3Xajdx4I9Z8NmsAuVg/CvFusx4DIDNO+pJrrHsCWZaRyxFkYy+hznpoPU1mOO+r2z5AUWUQWYOQJSBiFirTBj5cs/16dF2/J126gA0b4WmBB5tImqffFkBRJDM01XXOPHmGCBgJsUiQJBaXV7bWva76r+iJXsiyBCLxJiCdFcBTgGtEQ8uQAscTEQuLS0iP1m4GSLHr0BNeaOwN6Nwt5BO3sc556bXP3NcTN+n4uSAG+yAQCcrYPvA8jxSfAbeWRONjGS0DGRNQjPxdyrgNypQd6qfj0JhmGuakX6QLaqSV2o38rBt6pJ3+BpxmqBzaC89QJ2IrLE71n4XrUcefww0JgQoYzo4dgvThGNSPDRRmR545AeWLg7oZyucmSBO1WOU4LMdX0DrQAffDn56Lfvt778JoNdKvy5HxVYD37wcJVSIbrqJjV130AZDRSkTmo5idm8dMJGp6bv4fwjeE++s7DJDgr6Kgg5ts7EeiC79cvG3rIu9tEN/WU9ch964eLPPqP0PLyn4AU+gTVzRTocUAAAAASUVORK5CYII=";

    public override Guid ComponentGuid { get; } = new Guid("eec6d355-6056-41b0-b66a-0291ee4ba68b");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    public ProjectComponent_eec6d355() : base(GetResource(s_scriptDataId), s_scriptIconData,
        name: "Image generation (nano banana)",
        nickname: "Image generation (Nano Banana)",
        description: @"Generates images from prompts or by using a reference image using Nano Banana",
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
