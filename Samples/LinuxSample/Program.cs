using System;
using Eto.Forms;
using CSCore.SoundOut;
using CSCore.Codecs;

namespace LinuxSample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			OpenFileDialog openfileDialog = new OpenFileDialog () {
				CurrentFilter = CodecFactory.SupportedFilesFilterEn
			};
			if (openfileDialog.ShowDialog (new Form()) == DialogResult.Ok) {
				using (var source = CodecFactory.Instance.GetCodec (openfileDialog.FileName)) {
					using (var soundOut = new ALSoundOut ()) {
						soundOut.Initialize (source);
						soundOut.Play ();
						Console.WriteLine ("Press any key to exit.");
						Console.ReadKey ();
					}
				}
			}
		}
	}
}
