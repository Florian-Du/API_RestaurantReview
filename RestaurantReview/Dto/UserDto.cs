namespace RestaurantReview.Dto
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public byte[]? Salt { get; set; }
    }
}
