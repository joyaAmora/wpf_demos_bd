using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace wpf_demo_phonebook
{
    public class ContactModel : INotifyPropertyChanged
    {
        private int contactID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string mobile;
        
        public ContactModel()
        {
        }

        public int ContactID
        {
            get => contactID;
            set
            {
                contactID = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        public string Mobile
        {
            get => mobile;
            set
            {
                mobile = value;
                OnPropertyChanged();
            }
        }
        public string Info => $"{LastName}, {FirstName}";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
