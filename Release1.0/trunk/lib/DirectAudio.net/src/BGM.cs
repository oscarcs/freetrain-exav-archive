using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QuartzTypeLib;

namespace org.kohsuke.directaudio
{
	/// <summary>
	/// Use DirectShow to manage BGM.
	/// </summary>
	public class BGM : IDisposable
	{
		const int DS_NOTIFY_CODE = 123;
		const int WM_DS_NOTIFY = 0x8001;	// WM_APP+1
		const int EC_COMPLETE = 0x01;		// from evcode.h

        /// <summary>BGM object constructor</summary>
		public BGM() {
			// launch an invisible window to receive notification
			wnd = new NotificationWindow(this);
			createObjects();
		}

        // Create inner objects
        private void createObjects() {
			filter = new FilgraphManagerClass();
			mediaPos = (IMediaPosition)filter;
			mediaEvent = (IMediaEventEx)filter;

			mediaEvent.SetNotifyWindow(wnd.Handle.ToInt32(), WM_DS_NOTIFY, DS_NOTIFY_CODE);
		}

        /// <summary>BGM object disposed</summary>
        public void Dispose() {
			wnd.Dispose();
			releaseObjects();
		}

        // Release inner objects
		private void releaseObjects() {
			if (filter != null) {
			    Marshal.ReleaseComObject(filter);
				Marshal.ReleaseComObject(mediaPos);
				Marshal.ReleaseComObject(mediaEvent);
			}
			filter = null;
			mediaPos = null;
			mediaEvent = null;
		}

		private FilgraphManager filter;
		private IMediaPosition mediaPos;
		private IMediaEventEx mediaEvent;

        /// <summary> Window that receives notification. </summary>
		private Control wnd;

        /// <summary>BGM filename</summary>
		public string fileName {
			set {
				releaseObjects();
				createObjects();
				filter.RenderFile(value);
			}
		}

        /// <summary>play BGM</summary>
		public void run() {
			filter.Run();
		}

        /// <summary>pause BGM play</summary>
		public void pause() {
			filter.Pause();
		}
		
        /// <summary>stop BGM play</summary>
		public void stop() {
			filter.Stop();
		}

		/// <summary>BGM volume</summary>
        /// <value>0 to 100</value>
		public int volume {
			get {
				double db = ((IBasicAudio)filter).Volume / 100.0;
				// 10^(db/20))*100
				return (int)(Math.Pow(10,db / 20) * 100);
			}
			set {
				// log10(V/100)*20 = (log10(V)-2)*20
				int v = value;
				if (v <= 0) {
                    v=1;
                }
				((IBasicAudio)filter).Volume = (int)((Math.Log10(v) - 2) * 20 * 100);
			}
		}

		/// <summary>BGM loop play</summary>
        /// <value>true is loop play</value>
        /// <value>false is not loop play</value>
        public bool loop = true;

        // 
		internal void notify() {
			int code, param1, param2;

			while(true) {
				try {
					mediaEvent.GetEvent(out code, out param1, out param2, 0);
				} catch( COMException ) {
					return;
				}

				mediaEvent.FreeEventParams(code, param1, param2);

				if (code == EC_COMPLETE) {
					Debug.WriteLine("BGM: rewinded");
					// rewind to the start
					mediaPos.CurrentPosition = 0;
				}
			}
		}

		/// <summary>Window that receives notification from DirectShow.</summary>
		private class NotificationWindow : Control {
			private readonly BGM parent;

            internal NotificationWindow(BGM _parent) { this.parent = _parent; }

            protected override void WndProc(ref Message m) {
				if (m.Msg == WM_DS_NOTIFY) {
				    parent.notify();
                }
				base.WndProc(ref m);
			}
		}
	}
}
