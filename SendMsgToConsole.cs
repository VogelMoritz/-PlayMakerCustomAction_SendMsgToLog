// (c) Copyright Martin Ritter @ Büro Vogel Moritz GbR
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Keywords: Debug
// v1

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Debug)]
	[Tooltip("Sends a log message to Unity Console Log Window.")]

	public class SendMsgToConsole : FsmStateAction
	{
		[Tooltip("Info, Warning, or Error.")]
		public LogLevel logLevel;

		[Tooltip("Text to print to log window.")]
		public FsmString text;

		[Tooltip("Color of text.")]
		public FsmColor color;
		Color UnityColor;

		[Tooltip("Text style.")]
		public FsmBool bold;
		public FsmBool italic;

		string boldtagOpen = "";
		string boldtagClose = "";

		string italictagOpen = "";
		string italictagClose = "";


		public override void Reset()
		{
			logLevel = LogLevel.Info;
			text = "";
		}

		public override void OnEnter()
		{
			if (!string.IsNullOrEmpty(text.Value))

			UnityColor = color.Value;
			string hexcolor = ColorUtility.ToHtmlStringRGBA(UnityColor);

			if (bold.Value) {
				boldtagOpen = "<b>";
				boldtagClose = "</b>";
			};

			if (italic.Value) {
				italictagOpen = "<i>";
				italictagClose = "</i>";
			};

			string colortagOpen = "<color=#" + hexcolor + ">";
			string colortagClose = "</color>";

			string logtext = colortagOpen + boldtagOpen + italictagOpen + text.Value + italictagClose + boldtagClose + colortagClose;

			switch (logLevel){
				case LogLevel.Info:
				Debug.Log(logtext);
				break;

				case LogLevel.Error:
				Debug.LogError(logtext);
				break;

				case LogLevel.Warning:
				Debug.LogWarning(logtext);

				break;
			}

			Finish();
		}
	}
}

