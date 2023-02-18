using MMSApp.Models.DTO;
namespace MMSApp.Models.Entity
{
    public partial class Psp
    {
        public static implicit operator PSPDto(Psp psp)
        {
            PSPDto dto = new()
            {
                AcceptorCode = psp.AcceptorCode,
                Enabled = psp.Enabled,
                Alias = psp.Alias,
                CreateDate = psp.CreateDate,
                IsActive = psp.IsActive,
                SettlementIban = psp.SettlementIban,
                TlsHostCertificateFingerprint = psp.TlsHostCertificateFingerprint,
                CreatorUserId = psp.CreatorUserId,
                Id = psp.Id,
                IIN = psp.IIN,
                PspMmsPrivateKey = psp.PspMmsPrivateKey,
                ShaparakFtpPrivateKey = psp.ShaparakFtpPrivateKey,
                CutOffTime = psp.CutOffTime,
                WageIban = psp.WageIban,
                IsDeleted = psp.IsDeleted,
                Name = psp.Name,
                PasswordShaparak = psp.PasswordShaparak,
                PspMmsPassword = psp.PspMmsPassword,
                ShaparakFtpPassword = psp.ShaparakFtpPassword,
                PspMmsPublicKey = psp.PspMmsPublicKey,
                PspMmsUsername = psp.PspMmsUsername,
                ShaparakFtpPublicKey = psp.ShaparakFtpPublicKey,
                ShaparakFtpUsername = psp.ShaparakFtpUsername,
                StepsCount = psp.StepsCount,
                TerminalNo = psp.TerminalNo,
                UpdaterUserId = psp.UpdaterUserId,
                UpdateTime = psp.UpdateTime,
                UserShaparak = psp.UserShaparak,
            };
            return dto;
        }
        public static implicit operator Psp(PSPDto pspdto)
        {
            Psp psp = new()
            {
                AcceptorCode = pspdto.AcceptorCode,
                Enabled = pspdto.Enabled,
                Alias = pspdto.Alias,
                CreateDate = pspdto.CreateDate,
                IsActive = pspdto.IsActive,
                SettlementIban = pspdto.SettlementIban,
                TlsHostCertificateFingerprint = pspdto.TlsHostCertificateFingerprint,
                CreatorUserId = pspdto.CreatorUserId,
                Id = pspdto.Id,
                IIN = pspdto.IIN,
                PspMmsPrivateKey = pspdto.PspMmsPrivateKey,
                ShaparakFtpPrivateKey = pspdto.ShaparakFtpPrivateKey,
                CutOffTime = pspdto.CutOffTime,
                WageIban = pspdto.WageIban,
                IsDeleted = pspdto.IsDeleted,
                Name = pspdto.Name,
                PasswordShaparak = pspdto.PasswordShaparak,
                PspMmsPassword = pspdto.PspMmsPassword,
                ShaparakFtpPassword = pspdto.ShaparakFtpPassword,
                PspMmsPublicKey = pspdto.PspMmsPublicKey,
                PspMmsUsername = pspdto.PspMmsUsername,
                ShaparakFtpPublicKey = pspdto.ShaparakFtpPublicKey,
                ShaparakFtpUsername = pspdto.ShaparakFtpUsername,
                StepsCount = pspdto.StepsCount,
                TerminalNo = pspdto.TerminalNo,
                UpdaterUserId = pspdto.UpdaterUserId,
                UpdateTime = pspdto.UpdateTime,
                UserShaparak = pspdto.UserShaparak,
            };
            return psp;
        }
        /* public static implicit operator List<PSPDto>(List<Psp> psps)
         {
             List<PSPDto> list = new();
             foreach (Psp item in psps)
             {
                 list.Add(item);
             }
             return list;
         }*/
    }
}
