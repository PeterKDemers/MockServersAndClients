using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MockNotServerServiceHost
{
	public partial class MainWindowViewModel : INotifyPropertyChanged {
		#region events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region fields
		//Logger _Logger = null;
		DispatcherTimer _TimerBlink = new DispatcherTimer();
		#endregion

		#region ctor
        //public MainWindowViewModel(Logger logger)
        //{
        //    _Logger = logger;
		public MainWindowViewModel() {

			_TimerBlink.Tick += timerBlinkTick;
			_TimerBlink.Interval = new TimeSpan(0, 0, 0, 1, 0);

			LogInfo("MainViewViewModel() CONSTRUCTED");
		}
		#endregion
		#region timer related
		public void BlinkSequence(Brush foreground, Brush background) {
			if (foreground == null) {
				_TimerBlink.Stop();
				//MessageBackground = Brushes.White;
				return;
			}
			MessageForeground = foreground;
			//MessageBackground = background;
			_TimerBlink.Start();
		}
		private void timerBlinkTick(object sender, EventArgs e) {
			//Brush temp = MessageBackground;
			//MessageBackground = MessageForeground;
			//MessageForeground = temp;
		}
		#endregion
		#region Logging
		private void LogInfo(String msg) {
            //if (_Logger == null) {
            //    return;
            //}
            //_Logger.write(Logger.Level.Info, "MainWindowViewModel() " + msg);
		}
		private void LogError(String msg) {
            //if (_Logger == null) {
            //    return;
            //}
            //_Logger.write(Logger.Level.Error, "MainWindowViewModel() " + msg);
		}
		#endregion

		#region timer-oriented methods
		#endregion

		#region notification methods
		public void firePropertyChanged(string propertyName) {
			if ((this.PropertyChanged != null)) {
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void firePropertyChanged(MethodBase mb) {
			int n;

			if (((n = mb.Name.Length)
						> 4)) {
				if (((string.Compare(mb.Name.Substring(0, 3), "get", true) == 0)
							|| (string.Compare(mb.Name.Substring(0, 3), "set", true) == 0))) {
					firePropertyChanged(mb.Name.Substring(4));
				}
			}
		}
		#endregion

		#region properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _UpDownText;
        public string UpDownText {
            get { return _UpDownText; }
            set { _UpDownText = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _UpDownBackground;
        public Brush UpDownBackground {
            get { return _UpDownBackground; }
            set { _UpDownBackground = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox1Text;
        public string TextBox1Text {
            get { return _TextBox1Text; }
            set { _TextBox1Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox2Text;
        public string TextBox2Text {
            get { return _TextBox2Text; }
            set { _TextBox2Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox3Text;
        public string TextBox3Text {
            get { return _TextBox3Text; }
            set { _TextBox3Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox4Text;
        public string TextBox4Text {
            get { return _TextBox4Text; }
            set { _TextBox4Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox5Text;
        public string TextBox5Text {
            get { return _TextBox5Text; }
            set { _TextBox5Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox6Text;
        public string TextBox6Text {
            get { return _TextBox6Text; }
            set { _TextBox6Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox7Text;
        public string TextBox7Text {
            get { return _TextBox7Text; }
            set { _TextBox7Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox8Text;
        public string TextBox8Text {
            get { return _TextBox8Text; }
            set { _TextBox8Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox9Text;
        public string TextBox9Text {
            get { return _TextBox9Text; }
            set { _TextBox9Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox10Text;
        public string TextBox10Text {
            get { return _TextBox10Text; }
            set { _TextBox10Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox1Visibility;
        public Visibility TextBox1Visibility {
            get { return _TextBox1Visibility; }
            set { _TextBox1Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox2Visibility;
        public Visibility TextBox2Visibility {
            get { return _TextBox2Visibility; }
            set { _TextBox2Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox3Visibility;
        public Visibility TextBox3Visibility {
            get { return _TextBox3Visibility; }
            set { _TextBox3Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox4Visibility;
        public Visibility TextBox4Visibility {
            get { return _TextBox4Visibility; }
            set { _TextBox4Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox5Visibility;
        public Visibility TextBox5Visibility {
            get { return _TextBox5Visibility; }
            set { _TextBox5Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox6Visibility;
        public Visibility TextBox6Visibility {
            get { return _TextBox6Visibility; }
            set { _TextBox6Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox7Visibility;
        public Visibility TextBox7Visibility {
            get { return _TextBox7Visibility; }
            set { _TextBox7Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox8Visibility;
        public Visibility TextBox8Visibility {
            get { return _TextBox8Visibility; }
            set { _TextBox8Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox9Visibility;
        public Visibility TextBox9Visibility {
            get { return _TextBox9Visibility; }
            set { _TextBox9Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox10Visibility;
        public Visibility TextBox10Visibility {
            get { return _TextBox10Visibility; }
            set { _TextBox10Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Brush _MessageForeground;
		public Brush MessageForeground {
			get { return _MessageForeground; }
			set {
				_MessageForeground = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Brush _StatusBackground;
		public Brush StatusBackground {
			get { return _StatusBackground; }
			set {
				_StatusBackground = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Brush _StatusForeground;
		public Brush StatusForeground {
			get { return _StatusForeground; }
			set {
				_StatusForeground = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string _Status;
		public string Status {
			get { return _Status; }
			set { _Status = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string _Weight;
		public string Weight {
			get { return _Weight; }
			set { _Weight = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Brush _WeightBackground;
		public Brush WeightBackground {
			get { return _WeightBackground; }
			set {
				_WeightBackground = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Brush _WeightForeground;
		public Brush WeightForeground {
			get { return _WeightForeground; }
			set {
				_WeightForeground = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Brush _ComPortBackground;
		public Brush ComPortBackground {
			get { return _ComPortBackground; }
			set {
				_ComPortBackground = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		String _Version;
		public String Version {
			get { return _Version; }
			set {
				_Version = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		String _WeightLowLimit;
		public String WeightLowLimit {
			get { return _WeightLowLimit; }
			set { _WeightLowLimit = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		String _WeightHighLimit;
		public String WeightHighLimit {
			get { return _WeightHighLimit; }
			set { _WeightHighLimit = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Boolean _AutoIsChecked;
		public Boolean AutoIsChecked {
			get { return _AutoIsChecked; }
			set {
				_AutoIsChecked = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Boolean _BurstIsChecked;
		public Boolean BurstIsChecked {
			get { return _BurstIsChecked; }
			set {
				_BurstIsChecked = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Boolean _SpecialIsChecked;
		public Boolean SpecialIsChecked {
			get { return _SpecialIsChecked; }
			set {
				_SpecialIsChecked = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		String _ComPort;
		public String ComPort {
			get { return _ComPort; }
			set {
				_ComPort = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Visibility _MessageVisibility;
		public Visibility MessageVisibility {
			get { return _MessageVisibility; }
			set {
				_MessageVisibility = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		//Boolean _AcceptIsEnabled;
		//public Boolean AcceptIsEnabled {
		//	get { return _AcceptIsEnabled; }
		//	set {
		//		_AcceptIsEnabled = value;
		//		firePropertyChanged(MethodBase.GetCurrentMethod());
		//	}
		//}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Visibility _AcceptVisibility;
		public Visibility AcceptVisibility {
			get { return _AcceptVisibility; }
			set {
				_AcceptVisibility = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		//Boolean _RejectIsEnabled;
		//public Boolean RejectIsEnabled {
		//	get { return _RejectIsEnabled; }
		//	set {
		//		_RejectIsEnabled = value;
		//		firePropertyChanged(MethodBase.GetCurrentMethod());
		//	}
		//}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Visibility _RejectVisibility;
		public Visibility RejectVisibility {
			get { return _RejectVisibility; }
			set {
				_RejectVisibility = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Double _MessageOpacity;
		public Double MessageOpacity {
			get { return _MessageOpacity; }
			set { _MessageOpacity = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Double _WeightOpacity;
		public Double WeightOpacity {
			get { return _WeightOpacity; }
			set {
				_WeightOpacity = value;
				firePropertyChanged(MethodBase.GetCurrentMethod());
			}
		}
		#endregion
	}
}
