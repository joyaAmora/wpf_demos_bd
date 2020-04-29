using System.Collections.ObjectModel;
using wpf_demo_phonebook.ViewModels;

namespace wpf_demo_phonebook.ViewModels
{
    class ContactViewModel: BaseViewModel
    {

        private ObservableCollection<ContactModel> contacts;

        private ContactModel selectedContact;

        public ObservableCollection<ContactModel> Contacts
        {
            get => contacts;
            private set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }

        public ContactModel SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged();
            }
        }
    }
}
