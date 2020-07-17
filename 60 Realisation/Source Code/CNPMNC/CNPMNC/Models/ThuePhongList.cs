using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC.Models
{
    public class ThuePhongList
    {
        public Phong phongdetails { get; set; }
        public Thue_Phong thuePhongdetails { get; set; }
        public CT_Thue_Phong ctThuephongdetails { get; set; }
        public Khach_hang khachhangdetails { get; set; }
        public CT_Khach_Hang ctKhachhangdetails { get; set; }
    }
}