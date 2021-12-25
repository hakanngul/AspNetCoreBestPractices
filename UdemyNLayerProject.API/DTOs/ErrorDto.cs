using System;
using System.Collections.Generic;

namespace UdemyNLayerProject.API.DTOs
{
    public class ErrorDto
    {
        public List<String> Errors { get; set; }

        public int Status { get; set; }

        public ErrorDto()
        {
            Errors = new List<String>();
        }
    }
}