using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Constants
{
    public class Server
    {

        public const string REGISTER_STATUS_SUCCESS = "SUCCESS";
        public const string REGISTER_STATUS_INCORRECT_IDENTIFICATOR = "INCORRECT_IDENTIFICATOR";
        public const string REGISTER_STATUS_PHONE_USED = "PHONE_USED";

        public const string STATUS_SUCCESS = "SUCCESS";
        public const string STATUS_DENIED = "DENIED";

        public const string MESSAGE_STATUS_READED = "READED";
        public const string MESSAGE_STATUS_NOTREADED = "NOTREADED";
        public const string MESSAGE_STATUS_SENDED = "SENDED";
        public const string MESSAGE_STATUS_ERROR = "ERROR";
        public const string MESSAGE_FROM_CURRENT = "CURRENT";
        public const string MESSAGE_FROM_ANOTHER = "ANOTHER";

        public const string POLLS_STATUS_ACTIVE = "ACTIVE";
        public const string POLLS_STATUS_DEACTIVE = "DEACTIVE";
        public const string POLLS_USERANSWER_NOTANSWERED = "NOTANSWERED";
        public const string POLLS_USERANSWER_ACCEPTED = "ACCEPTED";
        public const string POLLS_USERANSWER_DENIED = "DENIED";

    }
}
