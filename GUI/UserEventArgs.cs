﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public enum UserEvent
    {
        LoadTable, LoadComboBox
    };
    public class UserEventArgs : EventArgs
    {
        private readonly UserEvent userEvent;
        private readonly Object data;

        public UserEventArgs(UserEvent userEvent, object data)
        {
            this.userEvent = userEvent;
            this.data = data;
        }

        public UserEvent UserEventType
        {
            get { return userEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}
