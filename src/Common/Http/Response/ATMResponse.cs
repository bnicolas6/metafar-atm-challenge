﻿using Metafar.ATM.Challenge.Common.Utils;
using System.Net;

namespace Metafar.ATM.Challenge.Common.Http.Response
{
    public class ATMResponse<T>    
    {
        public T Content { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<ATMError> Errors { get; set; }

        public bool IsValid
        {
            get
            {
                return Errors.IsNullOrEmpty();
            }
        }
    }
}
