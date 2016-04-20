using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Win10WebService;
using Win10_project.Annotations;
using Win10_project.Model;

namespace Win10_project.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public SingletonViewModel SingletonViewModel { get; private set; }

        public ViewModel()
        {
            SingletonViewModel = SingletonViewModel.Instance;
        }

        public ObservableCollection<Guest> GetallGuests()
        {
            var guestlist = new Facade();
            return null;
        } 

        #region Notify Property Change Support
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void
            OnPropertyChanged

            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
