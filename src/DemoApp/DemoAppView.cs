using System;
using System.IO;
using System.Windows.Forms;

namespace ExceptionReporting.DemoApp
{
	public partial class DemoAppView : Form
	{
		public DemoAppView()
		{
			InitializeComponent();

			urlConfigured.Click += Throw_Configured_Click;
			urlDefault.Click += Throw_NonConfigured_Click;
		    urlCustomMessage.Click += Throw_CustomMessage_Click;
		}

		private static void Throw_NonConfigured_Click(object sender, EventArgs e)
		{
			ShowExceptionReporter(false);
		}

		private static void Throw_Configured_Click(object sender, EventArgs e)
		{
			ShowExceptionReporter(true);
		}

        private static void Throw_CustomMessage_Click(object sender, EventArgs e)
        {
            try
            {
                SomeMethod();
            }
            catch (Exception exception)
            {
                var exceptionReporter = new ExceptionReporter();
                exceptionReporter.Show("This is a custom message", exception);
            }
        }

		private static void ShowExceptionReporter(bool useConfig) 
		{
			try
			{
				SomeMethod();
			}
			catch (Exception exception)
			{
				var exceptionReporter = new ExceptionReporter();

				if (useConfig)
					exceptionReporter.ReadConfig();
				
				exceptionReporter.Show(exception);
			}
		}

		private static void SomeMethod()
		{
			CallAnotherMethod();
		}

		private static void CallAnotherMethod()
		{
			AndAnotherOne();
		}

		private static void AndAnotherOne()
		{
			var exception = new IOException(
				"Unable to establish a connection with the Foo bank account service. The error number is #FFF474678.",
					new Exception(
						"This is an Inner Exception message - with a message that is not too small but perhaps it should be smaller"));
			throw exception;
		}
	}
}