namespace MMSApp.Models.DTO
{
    public partial class PSPDto
    {
        public long Id { get; set; }
        public string UserShaparak { get; set; }
        public string PasswordShaparak { get; set; }
        public string PspMmsUsername { get; set; }
        public string PspMmsPassword { get; set; }
        public string PspMmsPublicKey { get; set; }
        public string PspMmsPrivateKey { get; set; }
        public string ShaparakFtpPublicKey { get; set; }
        public string ShaparakFtpPrivateKey { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string ShaparakFtpUsername { get; set; }
        public string ShaparakFtpPassword { get; set; }
        public string IIN { get; set; }
        public string TerminalNo { get; set; }
        public string AcceptorCode { get; set; }
        public Nullable<byte> StepsCount { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatorUserId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<long> UpdaterUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<System.TimeSpan> CutOffTime { get; set; }
        public string SettlementIban { get; set; }
        public string WageIban { get; set; }
        public string TlsHostCertificateFingerprint { get; set; }
    }
}
