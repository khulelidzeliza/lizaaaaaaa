using lizaaaaaaa.Enum;

namespace lizaaaaaaa.Model;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public ACCOUNT_STATUS Status { get; set; } = ACCOUNT_STATUS.CODE_SENT;
    public string Email { get; set; }
    public string Password { get; set; }

    public string? VerificationCode { get; set; }


}
