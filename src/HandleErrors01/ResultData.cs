namespace HandleErrors01
{
    public class ResultData
    {
        public string Code { get; set; } = string.Empty;
        public string Msg { get; set; } = string.Empty;
        public void SetCodeMsg(string code, string msg)
        {
            Code = code;
            Msg = msg;
        }
    }
}
