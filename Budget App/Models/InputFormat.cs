using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget_App.Models
{
    public class InputFormat
    {
        private List<InputTypes> _format;

        public InputFormat()
        {
            _format = new List<InputTypes>();
        }

        public void Add(InputTypes type)
        {
            // Unique columns?
            if (!_format.Contains(type))
                _format.Add(type);
        }

        public bool Contains(InputTypes type)
        {
            return _format.Contains(type);
        }

        public int IndexOf(InputTypes type)
        {
            if (_format.Contains(type))
                return _format.IndexOf(type);
            else
                return -1;
        }

        public InputTypes this[int index]
        {
            get
            {
                if (index >= 0 && index <= _format.Count)
                    return _format[index];
                else
                    return InputTypes.NOTSET;
            }
        }
    }

    public enum InputTypes
    {
        Account,
        TransDate,
        Amount,
        Balance,
        Category,
        Description,
        Memo,
        Notes,
        TransType,
        NOTSET
    }
}
