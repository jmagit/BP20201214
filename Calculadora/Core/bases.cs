using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Aplication.Core {

    [DataContract]
    public class ObservableBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null) {
            Debug.Assert(
                string.IsNullOrEmpty(propertyName) ||
                (GetType().GetProperty(propertyName) != null),
                "Check that the property name exists for this instance.");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
