using System;
using System.Drawing;
using System.Collections;
using freetrain.world;

namespace freetrain.contributions.common
{
	/// <summary>
	/// IPreviewWorldBuilder ‚ÌŠT—v‚Ìà–¾‚Å‚·B
	/// </summary>
	public interface IPreviewWorldBuilder
	{
		World CreatePreviewWorld(Size minsizePixel, IDictionary options);
	}
}
