using System;
using System.Collections.Generic;

namespace Xamarin.Android.Prepare
{
	[Scenario (isDefault: false)]
	class Scenario_Required : Scenario
	{
		public Scenario_Required () : base ("Required", "Just the basic steps to quickly install required tools and generate build files.", Context.Instance)
		{
			NeedsGitSubmodules = true;
			NeedsCompilers = true;
			NeedsGitBuildInfo = true;
		}

		protected override void AddSteps (Context context)
		{
			if (context == null)
				throw new ArgumentNullException (nameof (context));

			Steps.Add (new Step_GenerateFiles (atBuildStart: true, onlyRequired: true));
			Steps.Add (new Step_PrepareExternalJavaInterop ());
		}
	}
}
