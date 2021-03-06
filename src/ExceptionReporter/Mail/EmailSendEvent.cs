﻿using System;
using ExceptionReporting.Core;

namespace ExceptionReporting.Mail
{
	/// <summary>
	/// Email send event - default implementation
	/// Override this to create your own or implement the IEmailSendEvent with your own class
	/// </summary>
	public class EmailSendEvent : IEmailSendEvent
	{
		/// <summary>
		/// email send completed
		/// </summary>
		public virtual void Completed(bool success)
		{
			Console.WriteLine("SMTP email sent: " + success);
		}

		/// <summary>
		/// Shows an error - only if occurred
		/// </summary>
		public virtual void ShowError(string message, Exception exception)
		{
			Console.WriteLine("SMTP email error: " + message);
		}
	}
}
