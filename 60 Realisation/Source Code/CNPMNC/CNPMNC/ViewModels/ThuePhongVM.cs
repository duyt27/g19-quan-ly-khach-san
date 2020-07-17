using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC.ViewModels
{
    public class ThuePhongVM
    {
        public int PhongID { get; set; }
        public DateTime NgayThue { get; set; }
        public string TenKhach { get; set; }
        public int LoaiKhachID { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
    }
}