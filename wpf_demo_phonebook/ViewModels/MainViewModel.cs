using System;
using System.Collections.ObjectModel;
using System.Windows;
using wpf_demo_phonebook.ViewModels.Commands;

namespace wpf_demo_phonebook.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        public ObservableCollection<ContactModel> Contacts
        {
            get => contacts;
            private set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }


        private ContactModel selectedContact;

        public ContactModel SelectedContact
        {
            get => selectedContact;
            set { 
                selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string criteria;

        public string Criteria
        {
            get { return criteria; }
            set { 
                criteria = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SearchContactCommand { get; set; }


        public MainViewModel()
        {
            SearchContactCommand = new RelayCommand(SearchContact);
            SelectedContact = PhoneBookBusiness.GetContactByID(1);

            Contacts = PhoneBookBusiness.getAllContacts();
            
        }

        private void SearchContact(object parameter)
        {
            string input = parameter as string;
            int output;

            if (!Int32.TryParse(input, out output))
            {
                Contacts = PhoneBookBusiness.GetContactsByName(input);
                if (Contacts.Count > 0)
                {
                    SelectedContact = Contacts[0];
                }
            } else
            {
                SelectedContact = PhoneBookBusiness.GetContactByID(output);
            }

            
        }
    }
}