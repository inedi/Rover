#if UNITY_5_3_OR_NEWER
#define NOESIS
using System;
using Noesis;
#else
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#endif
using RoverGUI.ViewModels;
using RoverGUI.Data.Entities;
using System.Timers;

namespace RoverGUI.Views
{
    public partial class ChatScreenView : UserControl
    {
        ChatScreenViewModel _context = new ChatScreenViewModel();

        private string textmessage;
        private int caretIndex;
        private const string caret = "_";
        private System.Timers.Timer caretTimer;
        bool caretvisible = true;

#if NOESIS
        protected TextBox textBox;
        protected ScrollViewer scroll;

        private void InitializeComponent()
        {
            GUI.LoadComponent(this, "Assets/Views/Screens/ChatScreenView.xaml");

            textBox = (TextBox)FindName(nameof(textBox));
            scroll = (ScrollViewer)FindName(nameof(scroll));
        }
#endif
        public ChatScreenView()
        {
            DataContext = _context;

            InitializeComponent();
            SetTimer();

            Loaded += OnLoaded;
            textBox.KeyUp += MoveCaret;

            scroll.MouseLeftButtonUp += (sender, e) => Keyboard.Focus(textBox);
            textBox.LostFocus += (sender, e) =>
            {
                caretTimer.Stop();
                caretvisible = false;
                SetCaretState();
            };
            textBox.GotFocus += (sender, e) =>
            {
                caretTimer.Start();
                caretvisible = true;
                SetCaretState();
            };
            
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(textBox);
            
        }

        #region TEMP emulate console
        //because NOESIS GetRectFromCharacterIndex(TextBox.CaretIndex).Location; not work ((
        //либо выкинуть весь код оставив стандартную каретку, либо сделать норм custom контрол не на основе таймера.

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            caretTimer = new System.Timers.Timer(500);
            caretTimer.Elapsed += OnTimedEvent;
            caretTimer.AutoReset = true;
            caretTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            SetCaretState();
        }

        private void SetCaretState()
        {
            #if NOESIS
            if (caretvisible == true)
            {
                textmessage = textBox.Text;
                caretIndex = textBox.CaretIndex;
                textmessage = textmessage.Replace(caret, "");
                if (textmessage.Length < caretIndex)
                    caretIndex = textmessage.Length;
                if (caretIndex < 0) caretIndex = 0;
                textmessage = textmessage.Insert(caretIndex, caret);
                textBox.Text = textmessage;
                textBox.CaretIndex = caretIndex;

                caretvisible = false;
                return;
            }
            else
            {
                textmessage = textBox.Text;
                caretIndex = textBox.CaretIndex;
                textmessage = textmessage.Replace(caret, "");
                textBox.Text = textmessage;
                if (textmessage.Length < caretIndex)
                    caretIndex = textmessage.Length;
                if (caretIndex < 0) caretIndex = 0;
                textBox.CaretIndex = caretIndex;

                caretvisible = true;
                return;
            }
            #endif
        }

        private void MoveCaret(object sender, KeyEventArgs e)
        {
            textmessage = textBox.Text;
            caretIndex = textBox.CaretIndex;
            textmessage = textmessage.Replace(caret, "");
            if (textmessage.Length < caretIndex)
                caretIndex = textmessage.Length;
            if (caretIndex < 0) caretIndex = 0;
            if (e.Key == Key.Delete && caretIndex!= textmessage.Length)
                textmessage = textmessage.Remove(caretIndex,1);
            if (e.Key == Key.Enter)
            {
                _context.Messages.Add(new MessageModel
                {
                    Message = "RVR: " + textmessage,
                    IsIncoming = false
                });
                textBox.Text = caret;
                scroll.ScrollToBottom();
                return;
            }
            textmessage = textmessage.Insert(caretIndex, caret);
            textBox.Text = textmessage;
            textBox.CaretIndex = caretIndex;
        }
#endregion
    }
}
