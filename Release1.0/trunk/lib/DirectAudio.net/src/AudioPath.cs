using System;
using DxVBLibA;

namespace org.kohsuke.directaudio
{
	/// <summary>
	/// AudioPath ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
	/// </summary>
	public class AudioPath : IDisposable
	{
        // Handle for DirectMusicAudioPath8
        internal DirectMusicAudioPath8 handle;

        // AudioPath object constructor
		internal AudioPath(DirectMusicAudioPath8 handle) {
			this.handle = handle;
		}

        /// <summary>
        /// AudioPath object disposed
        /// </summary>
		public void Dispose() {
			if (handle != null) {
			    System.Runtime.InteropServices.Marshal.ReleaseComObject(handle);
			}
			handle = null;
		}
	}
}
