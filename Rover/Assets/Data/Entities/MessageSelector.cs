#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System.Windows;
using System.Windows.Controls;
#endif

namespace RoverGUI.Data.Entities
{
    public class MessageSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is MessageModel)
            {
                MessageModel message = item as MessageModel;
                //в зависимости от того, какой вариант выбран, возвращаем конкретный шаблон
                if (message.IsIncoming == true)
                    return element.FindResource("IncomingMessageDataTemplate") as DataTemplate;
                else
                    return element.FindResource("OutcomingMessageDataTemplate") as DataTemplate;
            }
            return null;
        }
    }
}
