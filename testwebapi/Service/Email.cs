using System;
namespace testwebapi.Service
{
    public class Email:ISendMsg
    {
        public Email()
        {
           
        }
        public string SendEmail()
        {
            return "Email";
        }
    }
}
