using System.ComponentModel;

namespace MMSApp.Models.Entity
{
    public partial class Psp
    {
        [DisplayName("ردیف")]
        public long Id { get; set; }
        [DisplayName("نام کاریری شاپرک")]
        public string UserShaparak { get; set; }
        [DisplayName("رمز عبور شاپرک")]
        public string PasswordShaparak { get; set; }
        [DisplayName("نام کاربری Psp")]
        public string PspMmsUsername { get; set; }
        [DisplayName("کلمه عبور Psp")]
        public string PspMmsPassword { get; set; }
        [DisplayName("کلید عمومی Psp")]
        public string PspMmsPublicKey { get; set; }
        [DisplayName("کلید خصوصی Psp")]
        public string PspMmsPrivateKey { get; set; }
        [DisplayName("کلید عمومی Ftp شاپرک")]
        public string ShaparakFtpPublicKey { get; set; }
        [DisplayName("کلید خصوصی Ftp شاپرک")]
        public string ShaparakFtpPrivateKey { get; set; }
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("نام مستعار")]
        public string Alias { get; set; }
        [DisplayName("نام کاربری Ftp شاپرک")]
        public string ShaparakFtpUsername { get; set; }
        [DisplayName("کلمه عبور Ftp شاپرک")]
        public string ShaparakFtpPassword { get; set; }

        public string IIN { get; set; }
        [DisplayName("شماره ترمینال")]
        public string TerminalNo { get; set; }
        [DisplayName("کد تایید")]

        public string AcceptorCode { get; set; }
        public Nullable<byte> StepsCount { get; set; }
        public Nullable<bool> Enabled { get; set; }
        [DisplayName("حذف شده")]

        public bool IsDeleted { get; set; }
        [DisplayName("فعال شده")]

        public bool IsActive { get; set; }
        [DisplayName("ایجاد شده توسط")]

        public long CreatorUserId { get; set; }
        [DisplayName("تاریخ ایجاد")]

        public System.DateTime CreateDate { get; set; }
        [DisplayName("آخرین آپدیت")]

        public Nullable<long> UpdaterUserId { get; set; }
        [DisplayName("آپدیت تایم")]

        public Nullable<System.DateTime> UpdateTime { get; set; }
        [DisplayName("کات آف تایم")]

        public Nullable<System.TimeSpan> CutOffTime { get; set; }


        public string SettlementIban { get; set; }


        public string WageIban { get; set; }


        public string TlsHostCertificateFingerprint { get; set; }
    }
}
