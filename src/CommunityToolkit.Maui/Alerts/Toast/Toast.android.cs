﻿using Android.Widget;
using AndroidToast = Android.Widget.Toast;

namespace CommunityToolkit.Maui.Alerts;

public partial class Toast
{
	static AndroidToast? _nativeToast;
	
	/// <summary>
	/// Dismiss Toast
	/// </summary>
	public virtual partial Task Dismiss(CancellationToken token)
	{
		token.ThrowIfCancellationRequested();
		_nativeToast?.Cancel();
		return Task.CompletedTask;
	}

	/// <summary>
	/// Show Toast
	/// </summary>
	public virtual async partial Task Show(CancellationToken token)
	{
		await Dismiss(token);
		token.ThrowIfCancellationRequested();

		_nativeToast = AndroidToast.MakeText(Platform.AppContext, Text, (ToastLength)(int)Duration)
		                  ?? throw new Exception("Unable to create toast");
		_nativeToast.Show();
	}
}