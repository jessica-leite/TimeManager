namespace TimeManager.DTO
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string SecretAnswer { get; set; }
    }
}
