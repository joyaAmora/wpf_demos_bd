using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using wpf_demo_phonebook.ViewModels.Commands;

namespace wpf_demo_phonebook.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel _vm;
        public BaseViewModel VM
        {
            get { return _vm; }
            set
            {
                _vm = value;
                OnPropertyChanged();
            }
        }
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
        public RelayCommand SaveContactCommand { get; set; }
        public RelayCommand DeleteContactCommand { get; set; }
        public RelayCommand CreateContactCommand { get; set; }


        public MainViewModel()
        {
            VM = this;
            SearchContactCommand = new RelayCommand(SearchContact);
            SaveContactCommand = new RelayCommand(SaveContact);
            DeleteContactCommand = new RelayCommand(DeleteContact);
            CreateContactCommand = new RelayCommand(CreateContact);

            Contacts = PhoneBookBusiness.getAllContacts();
            SelectedContact = Contacts.First<ContactModel>();
            
        }

        private void SearchContact(object parameter)
        {
            Contacts = PhoneBookBusiness.getAllContacts();
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

        private void SaveContact(object c)
        {
            if (selectedContact.ContactID != 0)
            {
                int modif = PhoneBookBusiness.UpdateContact(SelectedContact);
            }
            else
            {
                int generatedNewId = PhoneBookBusiness.InsertContact(selectedContact);
                if (generatedNewId > 0)
                {
                    SelectedContact.ContactID = generatedNewId;
                    Contacts.Add(SelectedContact);

                    SelectedContact = Contacts.Last<ContactModel>();
                }
            }
        }        
        
        private void DeleteContact(object parameter)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Voulez-vous vraiment supprimer?", "Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int modif = PhoneBookBusiness.DeleteContact(SelectedContact);
                Contacts = PhoneBookBusiness.getAllContacts();
            }
                
        }

        private void CreateContact(object c)
        {
            ContactModel newContact = new ContactModel();

            SelectedContact = newContact;
        }
    }
}
