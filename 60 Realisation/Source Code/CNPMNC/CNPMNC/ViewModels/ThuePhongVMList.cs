using CNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC.ViewModels
{
    public class ThuePhongVMList
    {
        public Phong phong { get; set; }
        public Thue_Phong thuePhong { get; set; }
        public CT_Thue_Phong ctThuephong { get; set; }
        public Khach_hang khachhang { get; set; }
        public CT_Khach_Hang ctKhachhang { get; set; }
    }
}