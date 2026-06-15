namespace WebStudy.Models
{
    public class GameResult
    {
        public int Id { get; set; } //변수같은 함수
        public required string UserID { get; set; }
        public required string UserName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
