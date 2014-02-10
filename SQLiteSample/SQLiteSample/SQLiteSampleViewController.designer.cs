// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SQLiteSample
{
	[Register ("SQLiteSampleViewController")]
	partial class SQLiteSampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblOutput { get; set; }

		[Action ("btnAddPerson:")]
		partial void btnAddPerson (MonoTouch.Foundation.NSObject sender);

		[Action ("btnCreateDB:")]
		partial void btnCreateDB (MonoTouch.Foundation.NSObject sender);

		[Action ("btnGetCount:")]
		partial void btnGetCount (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lblOutput != null) {
				lblOutput.Dispose ();
				lblOutput = null;
			}
		}
	}
}
