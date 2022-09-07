using System;
using System.Collections.Generic;

namespace GoogleTextToSpeech.Scripts.Data
{
    [Serializable]
    public class BadRequestData
    {
        public Error error;
    }

    [Serializable]
    public class Error
    {
        public int code;
        public string message;
        public string status;
        public List<Detail> details;
    }

    [Serializable]
    public class Detail
    {
        public string reason;
        public string domain;
        public Metadata metadata;
    }

    [Serializable]
    public class Metadata
    {
        public string service;
    }
}