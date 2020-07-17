using CNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC.ViewModels
{
    public class ListPhongVM
    {
        public string TenPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public double DonGia { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}