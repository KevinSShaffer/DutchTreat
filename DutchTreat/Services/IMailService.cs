﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Services
{
    public interface IMailService
    {
        void SendMail(string to, string subject, string body);
    }
}
