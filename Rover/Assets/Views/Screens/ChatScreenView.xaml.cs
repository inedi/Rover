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


namespace RoverGUI.Views
{
    public partial class ChatScreenView : UserControl
    {
        ChatScreenViewModel _context = new ChatScreenViewModel();

        private string textmessage;
        private int caretIndex;
        private const string caret = "_";

        public ChatScreenView()
        {
            DataContext = _context;

            InitializeComponent();

            Loaded += OnLoaded;
            textBox.KeyUp += MoveCaret;
        }

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
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            textBox.Text = caret;
            Keyboard.Focus(textBox);

        }
        private void MoveCaret(object sender, KeyEventArgs e)
        {
            #region TEMP emulate console
            //NOESIS GetRectFromCharacterIndex(TextBox.CaretIndex).Location; not work 

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

            #endregion
        }
    }
}
