using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.Lab01
{
    internal class BirthdayPickerViewModel :INotifyPropertyChanged
    {

        private DateTime _date = DateTime.Today;
        private string _age;
        private string _chinese;
        private string _western;

        private RelayCommand<object> _submitCommand;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string Chinese
        {
            get { return _chinese; }
            set
            {
                _chinese = value;
                OnPropertyChanged();
            }
        }

        public string Western
        {
            get { return _western; }
            set
            {
                _western = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> SubmitCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand<object>(
                           SubmitImplementation));
            }
        }

        public int CalculateAge()
        {
            DateTime now = DateTime.Today;

            int age = now.Year - _date.Year;

            if (now.Month < _date.Month || (now.Month == _date.Month && now.Day < _date.Day))
                age--;

            return age;
        }


        private async void SubmitImplementation(object obj)
        {
            Clear();
            bool checkedAge=true;

            await Task.Run(() => Process(ref checkedAge));

            if (checkedAge && _date.Month == DateTime.Today.Month && _date.Day == DateTime.Today.Day)
                MessageBox.Show("Happy birthday, bruh !!!");
        }

        private void Clear()
        {
            Age = "";
            Chinese = "";
            Western = "";
        }

        private void Process(ref bool b)
        {
            int age = CalculateAge();
            if (age < 135 && age >= 0)
            {
                Age = "Your age is " + age;
                Chinese = "Chinese zodiac: " + ChinaZodiac();
                Western = "Western zodiac: " + WesternZodiac();
            }
            else
            {
                b = false;
                MessageBox.Show("Error, wrong age");
            }

        }
        

        private string ChinaZodiac()
        {
            switch (_date.Year%12)
            {
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }   
        }

        private string WesternZodiac()
        {
            if ((_date.Month == 3 && _date.Day >= 21) || (_date.Month == 4 && _date.Day <= 20))
                return "Aries";   
            if ((_date.Month == 4 && _date.Day >= 21) || (_date.Month == 5 && _date.Day <= 20))
                return "Taurus";   
            if ((_date.Month == 5 && _date.Day >= 21) || (_date.Month == 6 && _date.Day <= 21))
                return "Gemini";   
            if ((_date.Month == 6 && _date.Day >= 22) || (_date.Month == 7 && _date.Day <= 22))
                return "Cancer";   
            if ((_date.Month == 7 && _date.Day >= 23) || (_date.Month == 8 && _date.Day <= 23))
                return "Leo";   
            if ((_date.Month == 8 && _date.Day >= 24) || (_date.Month == 9 && _date.Day <= 23))
                return "Virgo";  
            if ((_date.Month == 9 && _date.Day >= 24) || (_date.Month == 10 && _date.Day <= 22))
                return "Libra";   
            if ((_date.Month == 10 && _date.Day >= 23) || (_date.Month == 11 && _date.Day <= 22))
                return "Scorpio";   
            if ((_date.Month == 11 && _date.Day >= 23) || (_date.Month == 12 && _date.Day <= 21))
                return "Sagittarius";
            if ((_date.Month == 12 && _date.Day >= 22) || (_date.Month == 1 && _date.Day <= 20))
                return "Capricorn";
            if ((_date.Month == 1 && _date.Day >= 21) || (_date.Month == 2 && _date.Day <= 19))
                return "Aquarius";
            return "Pisces";	
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
