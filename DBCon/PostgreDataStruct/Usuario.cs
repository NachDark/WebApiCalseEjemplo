﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCon.PostgreDataStruct
{
    public class UsuarioPostGre
    {
        public int id { get; set; }
        public string email { get; set; }
        public string[] apodos { get; set; }
        public imagen imagenusuario { get; set; }

    }
    public class imagen
    {
        public string imgbase { get; set; }
        public string cabezera { get; set; }
        public byte[] imgbin { get; set; }
    }
}