﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class UserAddInput: UserInfo
    {
        public string Password { get; set; }
    }
}
