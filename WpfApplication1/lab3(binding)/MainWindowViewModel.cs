using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab3_binding_
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public static string EventName { get; set; } 
        public static string EventDescription { get; set; }
        public static string EventPlace { get; set; }
        public static int RemindTime { get; set; }
        public List<string> TypeOfTime { get; set; }
        public static string SelectedTime { get; set; }
        private static bool _IsRepeat { get; set; }
        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }
        private static DateTime _EventDate = DateTime.Now;
        public static DateTime EventDate
        {
            get { return _EventDate.Date; }
            set
            {
                _EventDate = value.Date + _EventDate.TimeOfDay;
            }
        }
        public TimeSpan EventTime
        {
            get
            {
                return _EventDate.TimeOfDay;
            }

            set
            {
                
                _EventDate = _EventDate.Date + value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private static bool _isNotification = true;
        public bool IsNotification
        {
            get
            {
                return _isNotification;
            }

            set
            {
                _isNotification = value;
                DoPropertyChanged("IsNotification");
                ;
            }
        }
        public MainWindowViewModel()
        {
            TypeOfTime = new List<string>()
            {
                "Секунд",
                "Минут",
                "Часов",
                "Дней"
            };
            Save = new InputCommand();
            Cancel = new CancelCommand(); ;
        }
        public static bool IsReadyToInsert()
        {
            if ((String.IsNullOrEmpty(EventName)) || (String.IsNullOrEmpty(EventDescription)) || (String.IsNullOrEmpty(EventPlace)))
                return false;
            else return true;
        }
        public static void InsertToDataBase()
        {
            if (IsReadyToInsert() == true)
            {
                Events Event1 = new Events(EventName, EventDescription, EventPlace, SelectedTime, RemindTime, _isNotification, _IsRepeat, _EventDate);
                EventDataBaseEntities context = new EventDataBaseEntities();
                context.Events.Add(Event1);
                context.SaveChangesAsync();
                MessageBox.Show("Сохранение выполнено");
            }
            else MessageBox.Show("Заполните пустые поля!");
        }
    }

    
}
