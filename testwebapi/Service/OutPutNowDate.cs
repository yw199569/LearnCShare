using System;
namespace testwebapi.Service
{
    public class OutPutNowDate:IOutPutNowDate
    {
        private IOutPutNowDate _outPutNowDate;
        public OutPutNowDate(IOutPutNowDate outPutNowDate)
        {
            _outPutNowDate = outPutNowDate;
        }

        public string WriteDate()
        {
           return DateTime.Now.ToShortDateString();
        }


    }
}
