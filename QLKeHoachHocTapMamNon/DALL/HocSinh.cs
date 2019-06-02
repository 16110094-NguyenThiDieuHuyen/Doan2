//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            this.DanhGiaHocSinhNams = new HashSet<DanhGiaHocSinhNam>();
            this.DanhGiaHocSinhTuans = new HashSet<DanhGiaHocSinhTuan>();
            this.PhieuKhamSucKhoes = new HashSet<PhieuKhamSucKhoe>();
        }
    
        public string MaHS { get; set; }
        public string HoTen { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string ĐiaChi { get; set; }
        public string HoTenNT1 { get; set; }
        public string EmailNT1 { get; set; }
        public string DTNT1 { get; set; }
        public string HoTenNT2 { get; set; }
        public string EmailNT2 { get; set; }
        public string DTNT2 { get; set; }
        public string MaLop { get; set; }
        public byte[] Hinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaHocSinhNam> DanhGiaHocSinhNams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaHocSinhTuan> DanhGiaHocSinhTuans { get; set; }
        public virtual Lop Lop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKhamSucKhoe> PhieuKhamSucKhoes { get; set; }
    }
}
