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

namespace MockScadaServerClient
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
		public MainWindowViewModel() {

			//_TimerBlink.Tick += timerBlinkTick;
			//_TimerBlink.Interval = new TimeSpan(0, 0, 0, 1, 0);

			LogInfo("MainViewViewModel() CONSTRUCTED");
		}
		#endregion
		#region timer related
		public void BlinkSequence(Brush foreground, Brush background) {
			if (foreground == null) {
				_TimerBlink.Stop();
				return;
			}
			_TimerBlink.Start();
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
        string _TimeStampPing;
        public string TimeStampPing {
            get { return _TimeStampPing; }
            set { _TimeStampPing = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _UpDownBackground;
        public Brush UpDownBackground {
            get { return _UpDownBackground; }
            set { _UpDownBackground = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBoxEndpointText;
        public string TextBoxEndpointText {
            get { return _TextBoxEndpointText; }
            set { _TextBoxEndpointText = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox0Text;
        public string TextBox0Text {
            get { return _TextBox0Text; }
            set { _TextBox0Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
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
        string _TextBox11Text;
        public string TextBox11Text {
            get { return _TextBox11Text; }
            set { _TextBox11Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox12Text;
        public string TextBox12Text {
            get { return _TextBox12Text; }
            set { _TextBox12Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox13Text;
        public string TextBox13Text {
            get { return _TextBox13Text; }
            set { _TextBox13Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox14Text;
        public string TextBox14Text {
            get { return _TextBox14Text; }
            set { _TextBox14Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox15Text;
        public string TextBox15Text {
            get { return _TextBox15Text; }
            set { _TextBox15Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox16Text;
        public string TextBox16Text {
            get { return _TextBox16Text; }
            set { _TextBox16Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox17Text;
        public string TextBox17Text {
            get { return _TextBox17Text; }
            set { _TextBox17Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox18Text;
        public string TextBox18Text {
            get { return _TextBox18Text; }
            set { _TextBox18Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _TextBox19Text;
        public string TextBox19Text {
            get { return _TextBox19Text; }
            set { _TextBox19Text = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _LabelAnalogVisibility;
        public Visibility LabelAnalogVisibility {
            get { return _LabelAnalogVisibility; }
            set { _LabelAnalogVisibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _LabelStatusVisibility;
        public Visibility LabelStatusVisibility {
            get { return _LabelStatusVisibility; }
            set { _LabelStatusVisibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBoxEndpointVisibility;
        public Visibility TextBoxEndpointVisibility {
            get { return _TextBoxEndpointVisibility; }
            set { _TextBoxEndpointVisibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox0Visibility;
        public Visibility TextBox0Visibility {
            get { return _TextBox0Visibility; }
            set { _TextBox0Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
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
        Visibility _TextBox11Visibility;
        public Visibility TextBox11Visibility {
            get { return _TextBox11Visibility; }
            set { _TextBox11Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox12Visibility;
        public Visibility TextBox12Visibility {
            get { return _TextBox12Visibility; }
            set { _TextBox12Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox13Visibility;
        public Visibility TextBox13Visibility {
            get { return _TextBox13Visibility; }
            set { _TextBox13Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox14Visibility;
        public Visibility TextBox14Visibility {
            get { return _TextBox14Visibility; }
            set { _TextBox14Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox15Visibility;
        public Visibility TextBox15Visibility {
            get { return _TextBox15Visibility; }
            set { _TextBox15Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox16Visibility;
        public Visibility TextBox16Visibility {
            get { return _TextBox16Visibility; }
            set { _TextBox16Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox17Visibility;
        public Visibility TextBox17Visibility {
            get { return _TextBox17Visibility; }
            set { _TextBox17Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox18Visibility;
        public Visibility TextBox18Visibility {
            get { return _TextBox18Visibility; }
            set { _TextBox18Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Visibility _TextBox19Visibility;
        public Visibility TextBox19Visibility {
            get { return _TextBox19Visibility; }
            set { _TextBox19Visibility = value; firePropertyChanged(MethodBase.GetCurrentMethod()); }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox0Foreground;
        public Brush TextBox0Foreground {
            get { return _TextBox0Foreground; }
            set {
                _TextBox0Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox1Foreground;
        public Brush TextBox1Foreground {
            get { return _TextBox1Foreground; }
            set {
                _TextBox1Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox2Foreground;
        public Brush TextBox2Foreground {
            get { return _TextBox2Foreground; }
            set {
                _TextBox2Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox3Foreground;
        public Brush TextBox3Foreground {
            get { return _TextBox3Foreground; }
            set {
                _TextBox3Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox4Foreground;
        public Brush TextBox4Foreground {
            get { return _TextBox4Foreground; }
            set {
                _TextBox4Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox5Foreground;
        public Brush TextBox5Foreground {
            get { return _TextBox5Foreground; }
            set {
                _TextBox5Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox6Foreground;
        public Brush TextBox6Foreground {
            get { return _TextBox6Foreground; }
            set {
                _TextBox6Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox7Foreground;
        public Brush TextBox7Foreground {
            get { return _TextBox7Foreground; }
            set {
                _TextBox7Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox8Foreground;
        public Brush TextBox8Foreground {
            get { return _TextBox8Foreground; }
            set {
                _TextBox8Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox9Foreground;
        public Brush TextBox9Foreground {
            get { return _TextBox9Foreground; }
            set {
                _TextBox9Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox10Foreground;
        public Brush TextBox10Foreground {
            get { return _TextBox10Foreground; }
            set {
                _TextBox10Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox11Foreground;
        public Brush TextBox11Foreground {
            get { return _TextBox11Foreground; }
            set {
                _TextBox11Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox12Foreground;
        public Brush TextBox12Foreground {
            get { return _TextBox12Foreground; }
            set {
                _TextBox12Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox13Foreground;
        public Brush TextBox13Foreground {
            get { return _TextBox13Foreground; }
            set {
                _TextBox13Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox14Foreground;
        public Brush TextBox14Foreground {
            get { return _TextBox14Foreground; }
            set {
                _TextBox14Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox15Foreground;
        public Brush TextBox15Foreground {
            get { return _TextBox15Foreground; }
            set {
                _TextBox15Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox16Foreground;
        public Brush TextBox16Foreground {
            get { return _TextBox16Foreground; }
            set {
                _TextBox16Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox17Foreground;
        public Brush TextBox17Foreground {
            get { return _TextBox17Foreground; }
            set {
                _TextBox17Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox18Foreground;
        public Brush TextBox18Foreground {
            get { return _TextBox18Foreground; }
            set {
                _TextBox18Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Brush _TextBox19Foreground;
        public Brush TextBox19Foreground {
            get { return _TextBox19Foreground; }
            set {
                _TextBox19Foreground = value;
                firePropertyChanged(MethodBase.GetCurrentMethod());
            }
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
		#endregion
	}
}
